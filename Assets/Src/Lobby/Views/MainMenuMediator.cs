using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Dispatcher;
using Src.Lobby.Events;
using UnityEngine;

namespace Src.Lobby.Views
{
    public class MainMenuMediator : ILobbyScreenMediator
    {
        private readonly RectTransform _targetTransform;
        private readonly UIPrefabsConfig _uiPrefabsConfig;
        private readonly IEventDispatcher _eventDispatcher;

        private MainMenuView _view;

        public MainMenuMediator(RectTransform targetTransform)
        {
            _targetTransform = targetTransform;
            _uiPrefabsConfig = Resolver.Resolve<UIPrefabsConfig>();
            _eventDispatcher = Resolver.Resolve<IEventDispatcher>();
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
            _eventDispatcher.Dispatch(new MainMenuPlayClickedEvent());
        }
    }
}