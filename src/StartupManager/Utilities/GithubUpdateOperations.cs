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

internal class GithubUpdateOperation
{
    public GithubUpdateOperation()
    {
        _UpdateTask = Task.Run(CheckForUpdate);
        _CurrentVersionTask = Task.Run(GetCurrentVersionByTag);
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
        else return false; // False = failed
        return true; // True = success
    }

    internal async Task<string> GetLatestVersionAsync()
    {
        if (!await UpdateOperationAwaiter()) return null;
        return _GitAPIResponse?["tag_name"].ToString();
    }

    internal async Task<bool> IsUpdateAvailable()
    {
        if (!await UpdateOperationAwaiter()) return false;
        return await GetLatestVersionAsync() != Settings.Default.Version;
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
            if (!await UpdateOperationAwaiter()) return null;
            return DateTime.Parse(_CurrentVersion?["published_at"].ToString()).ToShortDateString();
        }

        if (!await UpdateOperationAwaiter()) return null;
        return DateTime.Parse(_GitAPIResponse?["published_at"].ToString()).ToShortDateString();
    }

    private async Task GetCurrentVersionByTag()
    {
        using var client = new HttpClient();
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
    private static ICollection<ProductInfoHeaderValue> Microsoft_Edge_Chromium_Windows_UserAgent()
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