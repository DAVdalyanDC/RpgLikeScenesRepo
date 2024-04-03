using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ModeElement : MonoBehaviour
{
    public Button button;

    public event Action<string> OnElementSelected;

    void OnEnable()
    {
        button.onClick.AddListener(ElementClicked);
    }
    
    void OnDisable()
    {
        button.onClick.RemoveListener(ElementClicked);
    }
    

    private void ElementClicked()
    {
        OnElementSelected?.Invoke(GetComponentInChildren<TMP_Text>().text);
    }

    private void Reset()
    {
        button = GetComponent<Button>();
    }
}
