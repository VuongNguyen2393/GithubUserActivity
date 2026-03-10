namespace GithubUserActivity.Utils
{
  public static class ConsoleHelper
  {
    public static void PrintTitle()
    {
      var title = "=================================\n===  GITHUB ACTIVITY CRAWLER  ===\n=================================";
      PrintColor(ConsoleColor.DarkMagenta, title);
    }

    public static void PrintHeader(string header)
    {
      PrintColor(ConsoleColor.DarkCyan, new string('-', header.Length));
      PrintColor(ConsoleColor.DarkCyan, header);
      PrintColor(ConsoleColor.DarkCyan, new string('-', header.Length));

    }

    public static void PrintRow(string row)
    {
      PrintColor(ConsoleColor.Gray, row);
    }

    private static void PrintColor(ConsoleColor color, string text)
    {
      Console.ForegroundColor = color;
      System.Console.WriteLine(text);
      Console.ResetColor();
    }

  }
}