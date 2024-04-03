using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using FactoryPattern.PopupMenu;
using Test;

namespace FactoryPattern.Menu
{
    public class MenuView : AbstractView<MenuController, MenuModel>
    {
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private Button _selectModeButton;
        [SerializeField] private Button _popupButton;
        [SerializeField] private RectTransform _container;

        private void Start()
        {
            _leaderboardButton.onClick.AddListener(OnLeaderBoardClicked);
            _selectModeButton.onClick.AddListener(OnSelectModeClicked);
            _popupButton.onClick.AddListener(OnPopupButtonClicked);
        }

        private void OnPopupButtonClicked()
        {
            UIManager.Instance.Show<PopupView, PopupController, PopupModel>(true);
        }

        private void OnLeaderBoardClicked()
        {
            UIManager.Instance.Show<LeaderboardView, LeaderboardController, LeaderboardModel>(false,new LeaderboardModel());
        }

        private void OnSelectModeClicked()
        {
            UIManager.Instance.Show<SelectModeView, SelectModeController, SelectModeModel>();
        }
        
        internal override void Initialize()
        {
           
        }
    }
}