using System.Net.Http.Json;
using GithubUserActivity.Models;
using GithubUserActivity.Services;
using GithubUserActivity.Utils;

namespace GithubUserActivity;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "GithubActivity");
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

            var response = await client.GetAsync($"https://api.github.com/users/{userName}/events");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Activity>>();
                if (data == null)
                {
                    System.Console.WriteLine("Request fail");
                    return;
                }
                JsonActivityParse.ListActivites(data);

            }
            else
            {
                System.Console.WriteLine("Invalid Request");
            }
        }
    }
}
