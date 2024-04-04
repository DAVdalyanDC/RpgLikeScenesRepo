using System;
using System.Collections.Generic;
using FactoryPattern;
using Test;
using UnityEngine;
using UnityEngine.UI;
using FactoryPattern.Menu;


public class LeaderboardView : AbstractView<LeaderboardController,LeaderboardModel>
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button sortButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private Toggle friendsToggle;
    [SerializeField] private Toggle globalsToggle;
    [SerializeField] private Toggle localsToggle;

    [SerializeField] private RectTransform container;
    [SerializeField] private LeaderboardEntryItem entryItemTemplatePrefab;

    private readonly List<LeaderboardEntryItem> _items = new List<LeaderboardEntryItem>();

    private bool _areItemsInitialized;

    private void Awake()
    {
        friendsToggle.onValueChanged.AddListener(delegate { ToggleChanged(LeaderboardType.Friends);});
        globalsToggle.onValueChanged.AddListener(delegate { ToggleChanged(LeaderboardType.Globals);});
        localsToggle.onValueChanged.AddListener(delegate { ToggleChanged(LeaderboardType.Locals);});
    }

    private void Start()
    {
       
        sortButton.onClick.AddListener(OnSortClicked);
        nextButton.onClick.AddListener(OnNextClicked);
        previousButton.onClick.AddListener(OnPreviousClicked);
        ToggleChanged(LeaderboardType.Friends);
        closeButton.onClick.AddListener(OnCloseButtonClicked);
        
    }

    private void ToggleChanged(LeaderboardType type)
    {
        if (type==LeaderboardType.Friends && friendsToggle.isOn||
            type==LeaderboardType.Globals && globalsToggle.isOn||
            type==LeaderboardType.Locals && localsToggle.isOn)
        {
            Controller.SetLeaderboardTypeAndCount(type);
        }
    }

    public void OnLeaderboardLoaded()
    {
        Debug.Log("LOADDs");
        SetNavigationState();
        if (!_areItemsInitialized)
        {

            PopulateItems();
            _areItemsInitialized = true;
            return;
        }

        RefreshItems();
    }

    
    
    private void RefreshItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
            if (i < Model.LeaderboardResult.Entries.Length)
            {
                item.gameObject.SetActive(true);
                int position = Controller.Count * Controller.Page + i;
                var entry = Model.LeaderboardResult.Entries[i];
                item.Setup(position, entry);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    private void PopulateItems()
    {
        for (int i = 0; i < Controller.Count; i++)
        {
            var item = Instantiate(entryItemTemplatePrefab, container);
            var entry = Model.LeaderboardResult.Entries[i];
            item.Setup(Controller.Count * Controller.Page + i, entry);
            _items.Add(item);
        }
    }

    private void OnSortClicked()
    {
        Controller.Sort();
    }

    private void OnPreviousClicked()
    {
        Controller.PreviousPage();
    }

    private void OnNextClicked()
    {
        Controller.NextPage();
    }

    private void OnCloseButtonClicked()
    {
        Controller.OnCloseButtonClicked();
    }

    private void SetNavigationState()
    {
        nextButton.interactable = Controller.HasNext;
        previousButton.interactable = Controller.Page > 0;
    }

    internal override void Initialize()
    {
        Debug.Log("initialising Leaderboard view");
    }
}