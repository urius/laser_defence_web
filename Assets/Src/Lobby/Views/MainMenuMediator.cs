using Cysharp.Threading.Tasks;
using SimpleDI;
using UnityEngine;

namespace Src.Lobby.Views
{
    public class MainMenuMediator : ILobbyScreenMediator
    {
        private readonly RectTransform _targetTransform;
        private readonly UIPrefabsConfig _uiPrefabsConfig;
        
        private MainMenuView _view;

        public MainMenuMediator(RectTransform targetTransform)
        {
            _targetTransform = targetTransform;
            _uiPrefabsConfig = Resolver.Resolve<UIPrefabsConfig>();
        }

        public void Mediate()
        {
            _view = Object.Instantiate(_uiPrefabsConfig.MainMenuScreenPrefab, _targetTransform);

            Subscribe();
        }

        public void Unmediate()
        {
            Unsubscribe();
            
            Object.Destroy(_view.gameObject);
            _view = null;
        }

        public UniTask ShowAsync()
        {
            return _view.AppearAsync();
        }

        public UniTask HideAsync()
        {
            return _view.DisappearAsync();
        }

        private void Subscribe()
        {
            _view.PlayButtonView.Clicked += OnPlayButtonClicked;
        }

        private void Unsubscribe()
        {
            _view.PlayButtonView.Clicked -= OnPlayButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            
        }
    }
}