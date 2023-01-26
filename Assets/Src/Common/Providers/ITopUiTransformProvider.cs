using UnityEngine;

namespace Src.Common.Providers
{
    public interface ITopUiTransformProvider
    {
        RectTransform RectTransform { get; }
    }
}