using System;
using System.Collections;
using System.Collections.Generic;
using FactoryPattern;
using UnityEngine;
using UnityEngine.UI;

namespace FactoryPattern.PopupMenu
{
    public class PopupModel : IModel
    {
        public string TitleText { get; set; }
        public string QuestionText { get; set; }
        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}