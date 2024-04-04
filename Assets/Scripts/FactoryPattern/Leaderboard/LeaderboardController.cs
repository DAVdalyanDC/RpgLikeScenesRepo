using System;
using FactoryPattern;
using FactoryPattern.Menu;
using Test;
using UnityEngine;

[Serializable]
public class LeaderboardController : AbstractController<LeaderboardModel>
{
    [field: SerializeField] public int Count { get; private set; }
    [field: SerializeField] public int Page { get; private set; }
    [field: SerializeField] public bool Descending { get; private set; }
    [field: SerializeField] public LeaderboardType CurrentLeaderboardType { get; private set; }


    public bool HasNext => (Page + 1) * Count < Model.LeaderboardResult.Total;

    public override void Show()
    {
        Model.OnLeaderboardLoaded += ((LeaderboardView)View).OnLeaderboardLoaded;
        Load();
    }

    public void SetLeaderboardTypeAndCount(LeaderboardType type)
    {
        CurrentLeaderboardType = type;
        switch (type)
        {
            case LeaderboardType.Friends :
                Count = 7;
                break;
            case LeaderboardType.Locals:
                Count = 13;
                break;
            case LeaderboardType.Globals:
                Count = Model.LeaderboardResult.Total;
                break;
        }

        Page = 0;
        //Load();
    }

    public void OnCloseButtonClicked()
    {
        UIManager.Instance.Show<MenuView, MenuController, MenuModel>();
    }

    private void Load()
    {
        Model.Load(Page, Count, Descending, CurrentLeaderboardType);
    }

    public void NextPage()
    {
        Page++;
        Load();
    }

    public void PreviousPage()
    {
        Page--;
        if (Page < 0)
        {
            Page = 0;
        }

        Load();
    }

    public void Sort()
    {
        Descending = !Descending;
        Load();
    }
}