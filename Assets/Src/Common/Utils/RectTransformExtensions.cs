using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Src.Common.Utils
{
    public static class RectTransformExtensions
    {
        public static UniTask AppearFromRightAsync(this RectTransform rectTransform, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.LeanSetLocalPosX(2 * rectTransform.sizeDelta.x);

            rectTransform.gameObject.LeanMoveLocalX(0, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());

            return tcs.Task;
        }

        public static UniTask AppearFromLeftAsync(this RectTransform rectTransform, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.LeanSetLocalPosX(-2 * rectTransform.sizeDelta.x);

            rectTransform.gameObject.LeanMoveLocalX(0, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());

            return tcs.Task;
        }
        
        public static UniTask DisappearToLeftAsync(this RectTransform rectTransform, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.gameObject.LeanMoveLocalX(-2 * rectTransform.sizeDelta.x, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());

            return tcs.Task;
        }
    }
}