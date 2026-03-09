namespace GithubUserActivity;

class Program
{
    static async Task Main(string[] args)
    {
        System.Console.Write("> ");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("Invalid Username");
            return;
        }
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");
        var response = await client.GetAsync($"https://api.github.com/users/{input}/events");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine(data);
        }
        else
        {
            System.Console.WriteLine("Invalid Request");
        }
    }
}
