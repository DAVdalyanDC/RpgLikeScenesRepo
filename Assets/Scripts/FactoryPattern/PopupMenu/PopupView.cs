using System;
using System.Collections;
using System.Collections.Generic;
using FactoryPattern;
using FactoryPattern.PopupMenu;
using Test;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

[RequireComponent(typeof(Button))]
public class PopupView : AbstractView<PopupController, PopupModel>
{
    public Button closeButton;
    public TMP_Text titleTextElement;
    public TMP_Text questionTextElement;
    public Button yesButton;
    public Button noButton;

    private void OnEnable()
    {
        yesButton.onClick.AddListener(YesButtonClicked);
        noButton.onClick.AddListener(NoButtonClicked);
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }
    private void OnDisable()
    {
        yesButton.onClick.RemoveListener(YesButtonClicked);
        noButton.onClick.RemoveListener(NoButtonClicked);
        closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        Destroy(gameObject);
    }
    private void YesButtonClicked()
    {
        Controller.YesButtonClicked();
    }
    
    private void NoButtonClicked()
    {
        Controller.NoButtonClicked();
    }
    
    //TODO: refactor
    internal override void Initialize()
    {
        
        if (titleTextElement != null && Model != null)
        {
            titleTextElement.text = Model.TitleText;
        }
        
        if (questionTextElement != null && Model != null)
        {
            questionTextElement.text = Model.QuestionText;
        }
        
    }
}


