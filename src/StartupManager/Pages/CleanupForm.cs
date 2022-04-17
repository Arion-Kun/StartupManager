using System.Windows.Forms;

namespace StartupManager.Pages;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DialogBoxes;
using Extensions;
using Microsoft.Win32;
using Native;
using Utilities;
public partial class CleanupForm : Form
{
    private static readonly string[] WhitelistedAnomolies =
    {
        "SecurityHealth"
    };
    public CleanupForm()
    {
        InitializeComponent();
        CleanupTask = Task.Run(PopulateList);
    }

    public static async Task<int> EntriesCount() => (await GenerateCleanupEntries()).Count;

    private List<CleanupEntry> ItemsUpForDisposal;
    private readonly Task CleanupTask;

    private async Task PopulateList()
    {
        ItemsUpForDisposal = await GenerateCleanupEntries();
        
        await TaskAwaiter.EnsureRunningOnMainThread();
        // ReSharper disable once CoVariantArrayConversion
        __EntryList.Items.AddRange(ItemsUpForDisposal.Select(e => e.ToString()).ToArray());
    }

    private static async Task<List<CleanupEntry>> GenerateCleanupEntries()
    {
        var taskList = new List<Task>();
        var cleanupEntries = new List<CleanupEntry>();
        if (ApplicationExtensions.HasRelevantPermission())
        {
            taskList.Add(
                TestIrregularity(cleanupEntries, RegistryExtensions.StartupLM, RegistryExtensions.StartupApprovedLM));
            taskList.Add(
                TestIrregularity(cleanupEntries, RegistryExtensions.StartupLM64, RegistryExtensions.StartupApprovedLM32));
        }
        taskList.Add(
            TestIrregularity(cleanupEntries, RegistryExtensions.Startup, RegistryExtensions.StartupApproved));
        
        await Task.WhenAll(taskList);
        PerformSanityCheck(cleanupEntries);
        return cleanupEntries;
    }

    private static void PerformSanityCheck(List<CleanupEntry> entries)
    {
        // This checks and removes any entries that are whitelisted
        foreach (var whitelistedAnomoly in WhitelistedAnomolies)
            if (entries.Any(x =>
                    x.ToString().Equals(whitelistedAnomoly, StringComparison.OrdinalIgnoreCase)))
                entries.RemoveAll(x =>
                    x.ToString().Equals(whitelistedAnomoly, StringComparison.OrdinalIgnoreCase));
        
        // Remove any duplicates
        entries.RemoveAll(x => entries.Count(a => a.ToString() == x.ToString()) > 1);
    }

    private static async Task TestIrregularity(List<CleanupEntry> entryBank, RegistryKey startupKey, RegistryKey startupApprovedKey)
    {
        var taskList = new List<Task>
        {
            Task.Run(()=> 
                entryBank.AddRange(
                    RegistryObjectTypeIrregularities(startupApprovedKey))),
            Task.Run(()=> 
                entryBank.AddRange(
                    RegistryObjectRelationshipIrregularities(startupKey))),
            Task.Run(()=> 
                entryBank.AddRange(
                    RegistryObjectAbandonmentIrregularities(startupApprovedKey)))
        };
        await Task.WhenAll(taskList);
    }

    private static IEnumerable<CleanupEntry> RegistryObjectAbandonmentIrregularities(RegistryKey approvedKey)
    {
        var entries = new List<CleanupEntry>();
        var approvedKeyNames = approvedKey.GetValueNames();
        foreach (var approvedKeyName in approvedKeyNames)
        {
            if (StartupContainsAnyExclusionary(approvedKeyName)) continue;
            if (CleanupEntry.Create(approvedKey, approvedKeyName, out var startupApprovedEntry0))
                entries.Add(startupApprovedEntry0);
        }
        
        return entries;
    }

    private static bool StartupContainsAnyExclusionary(string keyName)
    {
        var keyList = new List<RegistryKey> { RegistryExtensions.Startup };
        
        if (!ApplicationExtensions.IsElevated) return keyList.Any(key => key.GetValueNames().Contains(keyName));
        
        keyList.Add(RegistryExtensions.StartupLM);
        keyList.Add(RegistryExtensions.StartupLM64);

        return keyList.Any(key => key.GetValueNames().Contains(keyName));
    }
    private static IEnumerable<CleanupEntry> RegistryObjectRelationshipIrregularities(RegistryKey startupKey)
    {
        var entries = new List<CleanupEntry>();
        var startupKeyNames = startupKey.GetValueNames();
        foreach (var startupName in startupKeyNames)
        {
            if (startupKey.GetValueKind(startupName) != RegistryValueKind.String)
            {
                if (CleanupEntry.Create(startupKey, startupName, out var startupApprovedEntry0))
                    entries.Add(startupApprovedEntry0);
                continue;
            }
            
            var dirPath = Path.GetDirectoryName(RegistryExtensions.RemoveArguments(startupKey.GetValue(startupName).ToString()));
            if (!Directory.Exists(dirPath) && CleanupEntry.Create(startupKey, startupName, out var startupApprovedEntry1))
                entries.Add(startupApprovedEntry1);
            
            
        }

        return entries;
    }

    private static IEnumerable<CleanupEntry> RegistryObjectTypeIrregularities(RegistryKey startupApproved)
    {
        var entries = new List<CleanupEntry>();
        foreach (var cuStartupApprovedName in startupApproved.GetValueNames())
        {
            if (startupApproved.GetValueKind(cuStartupApprovedName) == RegistryValueKind.Binary)
                continue;
            if (CleanupEntry.Create(startupApproved, cuStartupApprovedName, out var startupApprovedEntry))
                entries.Add(startupApprovedEntry);
        }

        return entries;
    }

    // Get SelectedItems
    // Get SelectedIndicies
    // Remove Indicies from __EntryList
    // Delete Async each item from the list, then remove it from the ItemsUpForDisposal list
    private void __DeleteButton_Click(object sender, EventArgs e)
    {
        if (__EntryList.SelectedItems.Count == 0)
            return;
        var isSure = ConfirmDialogBox.ShowDialog("Delete Entries", "Are you sure you want to delete the selected entries?");
        
        if (!isSure) return;
        var items = __EntryList.SelectedItems.Cast<string>().ToArray();
        foreach (var item in items) 
            __EntryList.Items.Remove(item);
        Task.Run(()=> TryRemoveItems(items));
    }
    private void CleanupForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
            __DeleteButton_Click(sender, e);
        
        if (!e.Control || e.KeyCode != Keys.A) return;
        // Copy All
        for (var i = 0; i < __EntryList.Items.Count; i++)
            __EntryList.SetSelected(i, true);
    }

    private async Task TryRemoveItems(IEnumerable<string> entryName)
    {
        await CleanupTask;
        var failedEntries = new List<CleanupEntry>();
        foreach (var entry in entryName)
        {
            var entryToRemove = ItemsUpForDisposal.FirstOrDefault(x => x.ToString() == entry);
            if (entryToRemove == null) continue;
            if (entryToRemove.Remove())
                ItemsUpForDisposal.Remove(entryToRemove);
            else failedEntries.Add(entryToRemove);
        }
        
        // ReSharper disable once CoVariantArrayConversion
        __EntryList.Items.AddRange(failedEntries.Select(e => e.ToString()).ToArray());
    }


    private void __DeleteAllButton_Click(object sender, EventArgs e)
    {
        var isSure = ConfirmDialogBox.ShowDialog("Delete All", "Are you sure you want to delete all items?");
        if (isSure)
        {
            _ = Task.Run(async () =>
            {
                await CleanupTask;
                foreach (var cleanupEntry in ItemsUpForDisposal) 
                    cleanupEntry.Remove();
            });
        }
    }

    private void __AboutHeader_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        Drag();
    }
    private void __AboutLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        Drag();
    }
    private void Drag()
    {
        NativeMethods.ReleaseCapture();
        NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION,  0);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == NativeMethods.WM_NCHITTEST)
            m.Result = (IntPtr)NativeMethods.HT_CAPTION;
    }


    private const string TOOLTIP_TEXT = "The following entries were identified as non-functional, duplicates or corrupt.\n" +
                                        "Click the Delete button to remove one from the list.\n" +
                                        "Click the Delete All button to remove them from the list and the registry.\n" +
                                        "You can select multiple with Ctrl+Click or Shift+Click.";
    private void __HelpHoverButton_Click(object sender, EventArgs e) => __HelpInfo.Show(TOOLTIP_TEXT, __HelpHoverButton);
}