using System.Diagnostics.Contracts;

namespace GithubUserActivity.Models
{
  public class Activity
  {
    public required string Type { get; set; }
    public required Repo Repo { get; set; }
  }

  public class Repo
  {
    public required string Name { get; set; }
  }
}