using System;


namespace FactoryPattern.PopupMenu
{
    public class PopupController : AbstractController<PopupModel>
    {
        public event Action<bool> DecisionMade;

        public void YesButtonClicked()
        {
            DecisionMade?.Invoke(true);
        }

        public void NoButtonClicked()
        {
            DecisionMade?.Invoke(false);
        }
    }
}