
using GithubUserActivity.Models;
using GithubUserActivity.Utils;

namespace GithubUserActivity.Services
{
  public static class JsonActivityParse
  {
    public static void ListActivites(List<Activity> activities)
    {
      if (activities.Count == 0)
      {
        System.Console.WriteLine("This user have no activity");
        return;
      }

      var distinctEvents = activities.Select(a => a.Type).Distinct();
      var distinctRepos = activities.Select(a => a.Repo.Name).Distinct();
      ConsoleHelper.PrintHeader($"{"Activity",-15} | {"Count",-5} | {"Repository"}");
      var eventRepoDict = new Dictionary<(string, string), int>();
      foreach (var activityEvent in distinctEvents)
      {
        var repos = activities.Where(a => a.Type == activityEvent).Select(a => a.Repo.Name);
        foreach (var repo in repos)
        {
          var activity = activities.FirstOrDefault(a => a.Type == activityEvent && a.Repo.Name == repo);
          if (activity == null)
          {
            continue;
          }
          var key = (activityEvent, repo);
          if (!eventRepoDict.Keys.Contains(key))
          {
            eventRepoDict[key] = 1;
            continue;
          }
          eventRepoDict[key]++;
        }
      }

      var validEventRepoDict = eventRepoDict.Where(e => e.Value != 0);
      foreach (var validEvenRepo in validEventRepoDict)
      {
        ConsoleHelper.PrintRow($"{validEvenRepo.Key.Item1,-15} | {validEvenRepo.Value,-5} | {validEvenRepo.Key.Item2}");
      }
    }
  }
}