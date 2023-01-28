using Src.Common.Providers;

namespace Src.Common.View
{
    public class RootMediator
    {
        private UICanvasMediator _uiCanvasMediator;
        private readonly IUiCanvasTransformProvider _uiCanvasTransformProvider;

        public void Mediate()
        {
            _uiCanvasMediator = new UICanvasMediator();
            _uiCanvasMediator.Mediate();
        }

        public void Unmediate()
        {
            _uiCanvasMediator.Unmediate();
        }
    }
}