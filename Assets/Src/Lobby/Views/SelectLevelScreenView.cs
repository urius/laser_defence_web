using System;
using Cysharp.Threading.Tasks;
using Src.Common.Utils;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScreenView : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RawImage _levelImage;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _backButton;

    public event Action LeftButtonClicked;
    public event Action RightButtonClicked;
    public event Action BackButtonClicked;
    
    private void Awake()
    {
        _leftButton.onClick.AddListener(OnLeftButtonClicked);
        _rightButton.onClick.AddListener(OnRightButtonClicked);
        _backButton.onClick.AddListener(OnBackClicked);
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
        return _rectTransform.AppearFromRightAsync(_canvasGroup);
    }

    public UniTask DisappearAsync()
    {
        return _rectTransform.DisappearToRightAsync(_canvasGroup);
    }

    private void OnLeftButtonClicked()
    {
        LeftButtonClicked?.Invoke();
    }

    private void OnRightButtonClicked()
    {
        RightButtonClicked?.Invoke();   
    }
    
    private void OnBackClicked()
    {
        BackButtonClicked?.Invoke(); 
    }

}
