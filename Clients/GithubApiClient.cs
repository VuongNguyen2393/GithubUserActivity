using System.Net;
using System.Net.Http.Json;
using GithubUserActivity.Models;
using GithubUserActivity.Utils;

namespace GithubUserActivity.Clients
{
  public class GithubApiClient : IGithubApiClient
  {
    private readonly HttpClient _httpClient;

    public GithubApiClient(HttpClient httpClient)
    {
      _httpClient = httpClient;
      _httpClient.DefaultRequestHeaders.Add("User-Agent", "GithubActivity");
    }
    public async Task<List<Activity>?> GetUserActivitiesAsync(string userName)
    {
      try
      {
        var url = $"https://api.github.com/users/{userName}/events";
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
          return await response.Content.ReadFromJsonAsync<List<Activity>>();
        }

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
          ConsoleHelper.PrintWarning($"User {userName} Not Found (404)");
          return null;
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
          ConsoleHelper.PrintWarning($"API Authentication fail (401)");
          return null;
        }

        ConsoleHelper.PrintWarning("Something went wrong");
        return null;
      }
      catch (Exception ex)
      {
        ConsoleHelper.PrintError($"Unexpected error:{ex.Message}");
        return null;
      }
    }
  }
}