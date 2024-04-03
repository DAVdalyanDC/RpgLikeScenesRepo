using System;
using FactoryPattern;

public class LeaderboardModel :IModel
{
    public LeaderboardResult LeaderboardResult { get; private set; }
    public event Action OnLeaderboardLoaded;
            
    public void Load(int page,int count,bool descending,LeaderboardType type)
    {
        LeaderboardResult = LeaderboardDataLoader.Load(page, count, descending, type);
        OnLeaderboardLoaded?.Invoke();
    }

    public void Dispose()
    {
        if (OnLeaderboardLoaded == null) return;
        
        foreach (Delegate @delegate in OnLeaderboardLoaded.GetInvocationList())
        {
            OnLeaderboardLoaded -= (Action)@delegate;
        }
    }
}