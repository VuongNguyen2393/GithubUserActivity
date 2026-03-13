
using GithubUserActivity.Models;

namespace GithubUserActivity.Clients
{
  public interface IGithubApiClient
  {
    Task<List<Activity>?> GetUserActivitiesAsync(string userName);
  }
}