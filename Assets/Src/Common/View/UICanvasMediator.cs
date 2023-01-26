using SimpleDI;
using Src.Common.Model;
using Src.Common.Providers;
using Src.Lobby.Views;
using UnityEngine;

namespace Src.Common.View
{
    public class UICanvasMediator : IMediator
    {
        private readonly RectTransform _uiCanvasTransform;
        private readonly PlayerSessionModel _playerSessionModel;
        
        private ILobbyScreenMediator _currentMediator;

        public UICanvasMediator()
        {
            var uiCanvasTransformProvider = Resolver.Resolve<IUiCanvasTransformProvider>();
            _uiCanvasTransform = uiCanvasTransformProvider.RectTransform;
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
        }

        private async void OnGameStateChanged(GameState newState)
        {
            switch (newState)
            {
                case GameState.MainMenu:
                    _currentMediator = new MainMenuMediator(_uiCanvasTransform);
                    break;
            }

            if (_currentMediator == null) return;
            
            _currentMediator.Mediate();
            
            await _currentMediator.ShowAsync();
        }
    }
}