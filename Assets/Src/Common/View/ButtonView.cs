using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    public event Action Clicked = delegate { };

    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    private void OnClicked()
    {
        Clicked();
    }
}
