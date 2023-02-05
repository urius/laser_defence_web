using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Src.Common.Utils
{
    public static class RectTransformExtensions
    {
        public static UniTask AppearFromRightAsync(this RectTransform rectTransform, CanvasGroup canvasGroup = null, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.LeanSetLocalPosX(2 * rectTransform.sizeDelta.x);

            rectTransform.gameObject.LeanMoveLocalX(0, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());
            LeanCanvasAlpha(canvasGroup, 0, 1, duration);

            return tcs.Task;
        }

        public static UniTask AppearFromLeftAsync(this RectTransform rectTransform, CanvasGroup canvasGroup = null, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.LeanSetLocalPosX(-2 * rectTransform.sizeDelta.x);

            rectTransform.gameObject.LeanMoveLocalX(0, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());
            LeanCanvasAlpha(canvasGroup, 0, 1, duration);

            return tcs.Task;
        }
        
        public static UniTask DisappearToLeftAsync(this RectTransform rectTransform, CanvasGroup canvasGroup = null, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.gameObject.LeanMoveLocalX(-2 * rectTransform.sizeDelta.x, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());
            LeanCanvasAlpha(canvasGroup, 1, 0, duration);

            return tcs.Task;
        }
        
        public static UniTask DisappearToRightAsync(this RectTransform rectTransform, CanvasGroup canvasGroup = null, float duration = 0.7f)
        {
            var tcs = new UniTaskCompletionSource();

            rectTransform.gameObject.LeanMoveLocalX(2 * rectTransform.sizeDelta.x, duration)
                .setEaseOutQuad()
                .setOnComplete(() => tcs.TrySetResult());
            LeanCanvasAlpha(canvasGroup, 1, 0, duration);

            return tcs.Task;
        }

        private static void LeanCanvasAlpha(CanvasGroup canvasGroup, float from, float toValue, float duration)
        {
            if (canvasGroup == null) return;
            
            canvasGroup.alpha = from;
            canvasGroup.LeanAlpha(toValue, duration).setEaseOutQuad();
        }
    }
}