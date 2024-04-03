using FactoryPattern;
using UnityEngine;

public class SelectModeController : AbstractController<SelectModeModel>
{
    public void OnElementSelected(string data )
    {
        Debug.Log(data);
    }
}