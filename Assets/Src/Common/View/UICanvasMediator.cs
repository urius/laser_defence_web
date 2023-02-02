using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Model;
using Src.Common.Providers;
using Src.Lobby.Views;

namespace Src.Common.View
{
    public class UICanvasMediator : IMediator
    {
        private readonly IUiCanvasTransformProvider _uiCanvasTransformProvider;
        private readonly PlayerSessionModel _playerSessionModel;
        
        private ILobbyScreenMediator _currentMediator;

        public UICanvasMediator()
        {
            _uiCanvasTransformProvider = Resolver.Resolve<IUiCanvasTransformProvider>();
            _playerSessionModel = Resolver.Resolve<PlayerSessionModel>();
        }
        
        public void Mediate()
        {
            Subscribe();
        }

        public void Unmediate()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _playerSessionModel.GameStateChanged += OnGameStateChanged;
        }

        private void Unsubscribe()
        {
            _playerSessionModel.GameStateChanged -= OnGameStateChanged;
            
            if (_currentMediator != null)
            {
                _currentMediator.Unmediate();
                _currentMediator = null;
            }
        }

        private async void OnGameStateChanged(GameState newState)
        {
            var hideCurrentMediatorTask = _currentMediator?.HideAsync() ?? UniTask.CompletedTask;

            _currentMediator = newState switch
            {
                GameState.MainMenu => new MainMenuMediator(_uiCanvasTransformProvider.RectTransform),
                GameState.SelectLevelMenu => new SelectLevelScreenMediator(_uiCanvasTransformProvider.RectTransform),
                _ => null
            };

            if (_currentMediator == null) return;
            
            _currentMediator.Mediate();
            
            await _currentMediator.ShowAsync();
            await hideCurrentMediatorTask;
        }
    }
}