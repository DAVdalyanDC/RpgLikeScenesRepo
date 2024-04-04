using FactoryPattern;
using FactoryPattern.Menu;
using Test;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectModeView : AbstractView<SelectModeController, SelectModeModel>
{
    public ModeElement[] _elements;
    public Button backButton;

    private void OnBackButtonClicked()
    {
        Controller.OnBackButtonClicked();
    }

    void OnEnable()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
        
        foreach (var view in _elements)
        {
            view.OnElementSelected += HandleElementSelected;
        }
    }
    
    void OnDisable()
    {
        backButton.onClick.RemoveListener(OnBackButtonClicked);
        
        foreach (var view in _elements)
        {
            view.OnElementSelected -= HandleElementSelected;
        }
    }

    private void HandleElementSelected(string element)
    {
        Controller.OnElementSelected(element);
    }

    internal override void Initialize()
    {
    }
}