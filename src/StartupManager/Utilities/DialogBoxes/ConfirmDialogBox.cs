using System.Windows.Forms;

namespace Dawn.Apps.StartupManager.DialogBoxes;

using System;
using System.Drawing;
using Native;

public partial class ConfirmDialogBox  : Form
{
    
    private ConfirmDialogBox(string promptTitle, string promptMessage)
    {
        InitializeComponent();
        KeyPreview = true;
        TitleLabel.Text = promptTitle;
        MessageLabel.Text = promptMessage;
    }
    private ConfirmDialogBox(string promptTitle, string promptMessage, (string, Action) dialogLeftButton, (string, Action) dialogRightButton)
    {
        InitializeComponent();
        KeyPreview = true;
        TitleLabel.Text = promptTitle;
        MessageLabel.Text = promptMessage;
        __AcceptButton.Text = dialogLeftButton.Item1;
        __AcceptButton.Click += (_, _) => dialogLeftButton.Item2();
        __CancelButton.Text = dialogRightButton.Item1;
        __CancelButton.Click += (_, _) => dialogRightButton.Item2();
    }


    public static bool ShowDialog(string promptTitle, string promptMessage)
    {
        var form = new ConfirmDialogBox(promptTitle, promptMessage);
        var result = form.ShowDialog();
        return result == DialogResult.OK;
    }

    public static void ShowDialog(string promptTitle, string promptMessage, (string, Action) dialogLeftButton, (string, Action) dialogRightButton)
    {
        var form = new ConfirmDialogBox(promptTitle, promptMessage, dialogLeftButton, dialogRightButton);
        form.ShowDialog();
    }
    
    private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        Drag();
    }
    private void MessageLabel_MouseDown(object sender, MouseEventArgs e)
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

    private void ConfirmDialogBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Escape) return;
        DialogResult = DialogResult.Cancel;
        Close();
    }
}