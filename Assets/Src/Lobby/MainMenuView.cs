using Cysharp.Threading.Tasks;
using UnityEngine;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private ButtonView _playButtonView;
    public ButtonView PlayButtonView => _playButtonView;

    private async void Start()
    {
       await AppearAsync();
    }

    //TODO: move to common methods
    public UniTask AppearAsync()
    {
        var tcs = new UniTaskCompletionSource();

        var rectTrtansform = gameObject.transform as RectTransform;
        rectTrtansform.LeanSetLocalPosX(2 * rectTrtansform.sizeDelta.x);

        gameObject.LeanMoveLocalX(0, 0.7f)
            .setEaseOutQuad()
            .setOnComplete(() => tcs.TrySetResult());

        return tcs.Task;
    }
}
