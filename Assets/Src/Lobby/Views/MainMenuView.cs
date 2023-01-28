using Cysharp.Threading.Tasks;
using Src.Common.Utils;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private ButtonView _playButtonView;
    [SerializeField] private RectTransform _rectTransform;
    
    public ButtonView PlayButtonView => _playButtonView;
    
    public UniTask AppearAsync()
    {
        return _rectTransform.AppearFromRightAsync();
    }

    public UniTask DisappearAsync()
    {
        return _rectTransform.DisappearToLeftAsync();
    }
}
