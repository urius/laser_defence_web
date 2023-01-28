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
            switch (newState)
            {
                case GameState.MainMenu:
                    _currentMediator = new MainMenuMediator(_uiCanvasTransformProvider.RectTransform);
                    break;
            }

            if (_currentMediator == null) return;
            
            _currentMediator.Mediate();
            
            await _currentMediator.ShowAsync();
        }
    }
}