using System;
using System.Collections;
using System.Collections.Generic;
using FactoryPattern;
using FactoryPattern.PopupMenu;
using UnityEngine;
using UnityEngine.UI;

public class PopupView : AbstractView<PopupController, PopupModel>
{
    public Button closeButton;

    private void OnEnable()
    {
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        Destroy(gameObject);
    }

    internal override void Initialize()
    {
        
    }
}


