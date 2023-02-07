using Cysharp.Threading.Tasks;
using Src.Common.Utils;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private ButtonView _playButtonView;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private CanvasGroup _canvasGroup;
    
    public ButtonView PlayButtonView => _playButtonView;
    
    public UniTask AppearAsync()
    {
        return _rectTransform.AppearFromLeftAsync(_canvasGroup);
    }

    public UniTask DisappearAsync()
    {
        return _rectTransform.DisappearToLeftAsync(_canvasGroup);
    }
}
