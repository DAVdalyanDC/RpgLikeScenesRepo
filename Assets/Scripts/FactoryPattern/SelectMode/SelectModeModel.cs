using System.Collections;
using System.Collections.Generic;
using FactoryPattern;
using UnityEngine;

public class SelectModeModel :IModel
{
   public string SelectedElement { get; private set; }

   public void SelectElement(string element)
   {
      SelectedElement = element;
   }

   public void Dispose()
   {
      // TODO release managed resources here
   }
}
