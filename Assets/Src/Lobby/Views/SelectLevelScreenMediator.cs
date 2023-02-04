using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Dispatcher;
using Src.Lobby.Events;
using UnityEngine;

namespace Src.Lobby.Views
{
    public class SelectLevelScreenMediator : ILobbyScreenMediator
    {
        private readonly RectTransform _targetTransform;
        private readonly UIPrefabsConfig _uiPrefabsConfig;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly PlayerSessionModel _playerSessionModel;
        private readonly CellConfigProvider _cellConfigProvider;
        
        private SelectLevelScreenView _view;
        private LevelImageRenderer _levelImageRenderer;

        public SelectLevelScreenMediator(RectTransform targetTransform)
        {
            _targetTransform = targetTransform;
            
            _playerSessionModel = Resolver.Resolve<PlayerSessionModel>();
            _cellConfigProvider = Resolver.Resolve<CellConfigProvider>();
            _uiPrefabsConfig = Resolver.Resolve<UIPrefabsConfig>();
            _eventDispatcher = Resolver.Resolve<IEventDispatcher>();
        }

        public void Mediate()
        {
            _view = Object.Instantiate(_uiPrefabsConfig.SelectLevelScreenPrefab, _targetTransform);
            _levelImageRenderer = Object.Instantiate(_uiPrefabsConfig.LevelImageRenderer);

            DisplayLevel(_playerSessionModel.SelectedLevelConfig);
            UpdateButtons();

            Subscribe();
        }

        public void Unmediate()
        {
            Unsubscribe();
            
            Object.Destroy(_view.gameObject);
            Object.Destroy(_levelImageRenderer.gameObject);

            _view = null;
            _levelImageRenderer = null;
        }

        private void UpdateButtons()
        {
            _view.SetLeftButtonInteractable(_playerSessionModel.HasPreviousLevel());
            _view.SetRightButtonInteractable(_playerSessionModel.HasNextLevel());
        }

        private void DisplayLevel(LevelConfig levelConfig)
        {
            _levelImageRenderer.RenderLevel(levelConfig, _cellConfigProvider);
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
            _view.LeftButtonClicked += OnLeftButtonClicked;
            _view.RightButtonClicked += OnRightButtonClicked;
            _playerSessionModel.SelectedLevelChanged += OnSelectedLevelChanged;
        }

        private void Unsubscribe()
        {
            _view.LeftButtonClicked -= OnLeftButtonClicked;
            _view.RightButtonClicked -= OnRightButtonClicked;
            _playerSessionModel.SelectedLevelChanged -= OnSelectedLevelChanged;
        }

        private void OnLeftButtonClicked()
        {
            _eventDispatcher.Dispatch(new SelectLevelScreenChangeLevelClickedEvent(-1));
        }

        private void OnRightButtonClicked()
        {
            _eventDispatcher.Dispatch(new SelectLevelScreenChangeLevelClickedEvent(1));
        }

        private void OnSelectedLevelChanged(LevelConfig selectedLevel)
        {
            DisplayLevel(_playerSessionModel.SelectedLevelConfig);
            UpdateButtons();
        }
    }
}