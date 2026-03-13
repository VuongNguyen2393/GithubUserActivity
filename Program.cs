using System.Net.Http.Json;
using GithubUserActivity.Clients;
using GithubUserActivity.Models;
using GithubUserActivity.Services;
using GithubUserActivity.Utils;

namespace GithubUserActivity;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var githubClient = new GithubApiClient(httpClient);
        ConsoleHelper.PrintTitle();
        while (true)
        {

            System.Console.Write("> ");
            var userName = Console.ReadLine();

            if (string.IsNullOrEmpty(userName))
            {
                System.Console.WriteLine("Invalid Username");
                return;
            }

            var response = await githubClient.GetUserActivitiesAsync(userName);
            if (response != null)
            {
                JsonActivityParse.ListActivites(response);
            }
            else
            {
                System.Console.WriteLine("Invalid Request");
            }
        }
    }
}
