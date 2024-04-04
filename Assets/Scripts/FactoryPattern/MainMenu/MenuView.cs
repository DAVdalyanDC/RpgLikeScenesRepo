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
            Controller.OnPopupButtonClicked();
        }

        private void OnLeaderBoardClicked()
        {
            Controller.OnLeaderBoardClicked();
        }

        private void OnSelectModeClicked()
        {
          Controller.OnSelectModeClicked();
        }
        
        internal override void Initialize()
        {
           
        }
    }
}