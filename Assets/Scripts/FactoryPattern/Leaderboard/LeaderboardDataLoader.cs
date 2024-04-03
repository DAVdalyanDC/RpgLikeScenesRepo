using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class LeaderboardDataLoader
{
    public static LeaderboardResult Load(int page, int count, bool descending,LeaderboardType type)
    {
        var dataTextAsset = Resources.Load<TextAsset>($"Data/leaderboard_{type.ToString().ToLower()}");
        var entries = JsonConvert.DeserializeObject<LeaderboardEntryInfo[]>(dataTextAsset.text);
        var result =(descending 
            ? entries.OrderByDescending(info => info.Score)
            : entries.OrderBy(info => info.Score))
            .AsEnumerable();
        result = result.Skip(page * count).Take(count);
        return new LeaderboardResult(result.ToArray(), entries.Length);
    }
}