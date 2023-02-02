using System;
using Cysharp.Threading.Tasks;
using Src.Common.Utils;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScreenView : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RawImage _levelImage;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _startButton;

    public event Action LeftButtonClicked;
    public event Action RightButtonClicked;
    
    private void Awake()
    {
        _leftButton.onClick.AddListener(OnLeftButtonClicked);
        _rightButton.onClick.AddListener(OnRightButtonClicked);
    }

    private void OnDestroy()
    {
        _leftButton.onClick.RemoveListener(OnLeftButtonClicked);
        _rightButton.onClick.RemoveListener(OnRightButtonClicked);
    }

    public void SetLeftButtonInteractable(bool isInteractable)
    {
        _leftButton.interactable = isInteractable;
    }

    public void SetRightButtonInteractable(bool isInteractable)
    {
        _rightButton.interactable = isInteractable;
    }

    public UniTask AppearAsync()
    {
        return _rectTransform.AppearFromRightAsync();
    }

    public UniTask DisappearAsync()
    {
        return _rectTransform.DisappearToLeftAsync();
    }

    private void OnLeftButtonClicked()
    {
        LeftButtonClicked?.Invoke();
    }

    private void OnRightButtonClicked()
    {
        RightButtonClicked?.Invoke();   
    }
}
