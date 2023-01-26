using UnityEngine;

namespace Src.Common.Providers
{
    public interface IUiCanvasTransformProvider
    {
        RectTransform RectTransform { get; }
    }
}