using FactoryPattern;
using FactoryPattern.Menu;
using Test;
using UnityEngine;

public class SelectModeController : AbstractController<SelectModeModel>
{
    public void OnElementSelected(string data)
    {
        Model.SelectElement(data);
        Debug.Log(data);
    }
    public void OnBackButtonClicked()
    {
        UIManager.Instance.Show<MenuView, MenuController, MenuModel>();
    }
}