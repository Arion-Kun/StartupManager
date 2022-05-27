namespace StartupManager.Utilities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Properties;
using Timer = System.Timers.Timer;

internal class GithubUpdateOperation
{
    internal static GithubUpdateOperation Instance { get; } = new();
    private GithubUpdateOperation()
    {
        _UpdateTask = Task.Run(CheckForUpdate);
        _CurrentVersionTask = Task.Run(GetCurrentVersionByTag);
        
        // 6 Hours may be a lot but there doesn't seem to be much need for drastic updates to this program so a long delay is fine.
        // The UI feeds from the instance JObject so it's fine to update it from a background thread.
        var updateTick = new Timer(TimeSpan.FromHours(6).TotalMilliseconds);
        updateTick.Elapsed += (_, _) => Task.Run(CheckForUpdate);
        updateTick.Start();
    }

    private async Task CheckForUpdate()
    {
        using var client = new HttpClient();
        
        foreach (var productInfoHeaderValue in Microsoft_Edge_Chromium_Windows_UserAgent())
            client.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue); // We set our user agent
        
        var response = await client.GetAsync(Settings.Default.RepoAPILink);
        if (response.StatusCode == HttpStatusCode.NotFound) return;
        
        var content = await response.Content.ReadAsStringAsync();
        _GitAPIResponse = JObject.Parse(content);
    }

    private readonly Task _UpdateTask;
    private readonly Task _CurrentVersionTask;
    private JObject _GitAPIResponse { get; set; }
    private JObject _CurrentVersion { get; set; }

    private async Task<bool> UpdateOperationAwaiter()
    {
        if (_UpdateTask != null)
            await _UpdateTask;
        else return false; // False = failed
        if (_CurrentVersion != null)
            await _CurrentVersionTask;
        return true; // True = success
    }

    internal async Task<string> GetLatestVersionAsync()
    {
        if (!await UpdateOperationAwaiter()) return null;
        return _GitAPIResponse?["tag_name"].ToString().Replace("v", string.Empty);
    }

    internal async Task<bool> IsUpdateAvailable()
    {
        if (!await UpdateOperationAwaiter()) return false;
        var latestVersion = await GetLatestVersionAsync();
        if (latestVersion == null) return false;
        if (Version.TryParse(CurrentVersionConstants.VERSION, out var currentVersion))
            return Version.TryParse(latestVersion, out var latestVersionParsed) &&
                   latestVersionParsed > currentVersion;
        return false;
    }

    internal async Task<string> GetLatestDownloadURL()
    {
        if (!await UpdateOperationAwaiter()) return null;
        return _GitAPIResponse?["assets"][0]["browser_download_url"].ToString();
    }
    internal async Task OpenDownloadLinkURL() => Process.Start(await GetLatestDownloadURL());

    internal async Task<string> GetBuildDateToShortDateString(Versioning version)
    {
        if (version == Versioning.Current)
        {
            if (!await UpdateOperationAwaiter() || _CurrentVersion == null) return null;
            return DateTime.Parse(_CurrentVersion?["published_at"].ToString()).ToShortDateString();
        }

        if (!await UpdateOperationAwaiter()) return null;
        return DateTime.Parse(_GitAPIResponse?["published_at"].ToString()).ToShortDateString();
    }

    private async Task GetCurrentVersionByTag()
    {
        using var client = new HttpClient();
        foreach (var productInfoHeaderValue in Microsoft_Edge_Chromium_Windows_UserAgent())
            client.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue); // We set our user agent
        
        var response = await client.GetAsync(string.Format(TAG_ENDPOINT, CurrentVersionConstants.VERSION));
        if (response.StatusCode == HttpStatusCode.NotFound) return;
        
        var content = await response.Content.ReadAsStringAsync();
        _CurrentVersion = JObject.Parse(content);
    }

    private const string TAG_ENDPOINT = "https://api.github.com/repos/Arion-Kun/StartupManager/releases/tags/{0}";

    internal enum Versioning
    {
        Current,
        Latest
    }
    private static IEnumerable<ProductInfoHeaderValue> Microsoft_Edge_Chromium_Windows_UserAgent()
    {
        var x = new List<ProductInfoHeaderValue>
        {
            new(new ProductHeaderValue("Mozilla", "5.0")),
            new(new ProductHeaderValue("AppleWebKit", "537.36")),
            new(new ProductHeaderValue("Chrome", "99.0.4844.74")),
            new(new ProductHeaderValue("Safari", "537.36")),
            new(new ProductHeaderValue("Edg", "99.0.1150.46"))
        };
        return x;
    }
}