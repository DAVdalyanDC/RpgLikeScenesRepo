using FactoryPattern.PopupMenu;
using Test;
using UnityEngine;

namespace FactoryPattern.Menu
{
    public class MenuController : AbstractController<MenuModel>
    {
        public void OnPopupButtonClicked()
        {
            var popupModel = new PopupModel
            {
                TitleText = "Exit Game",
                QuestionText = "Do you want to leave the game?"
            };

            var controller = UIManager.Instance.Show<PopupView, PopupController, PopupModel>(true, popupModel);

            controller.DecisionMade += OnPopupDecisionMade;
            
                
            void OnPopupDecisionMade(bool obj)
            {
                controller.DecisionMade -= OnPopupDecisionMade;
                Debug.Log(obj ? "yes" : "no");
            }
        }

        

        public void OnLeaderBoardClicked()
        {
            UIManager.Instance.Show<LeaderboardView, LeaderboardController, LeaderboardModel>(false,
                new LeaderboardModel());
        }

        public void OnSelectModeClicked()
        {
            UIManager.Instance.Show<SelectModeView, SelectModeController, SelectModeModel>();
        }

    }
}