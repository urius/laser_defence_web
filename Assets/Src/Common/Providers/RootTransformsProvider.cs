using UnityEngine;

namespace Src.Common.Providers
{
    public class RootTransformsProvider : ITopUiTransformProvider, IUiCanvasTransformProvider, IRootGameTransformProvider
    {
        private RectTransform _topUiTransform;
        private RectTransform _uiCanvasTransform;

        RectTransform ITopUiTransformProvider.RectTransform => _topUiTransform;
        RectTransform IUiCanvasTransformProvider.RectTransform => _uiCanvasTransform;
        public Transform Transform { get; private set; }

        public void Setup(RectTransform topUiTransform, RectTransform uiCanvasTransform, Transform rootGameTransform)
        {
            _topUiTransform = topUiTransform;
            _uiCanvasTransform = uiCanvasTransform;
            Transform = rootGameTransform;
        }
    }
}