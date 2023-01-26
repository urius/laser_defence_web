using SimpleDI;
using Src.Common.Installers;
using Src.Common.Model;
using Src.Common.View;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    [SerializeField] private RectTransform _uiCanvasTransform;
    [SerializeField] private RectTransform _topUICanvasTransform;
    [SerializeField] private Transform _gameRootTransform;
    [SerializeField] private PlayerSessionModel _playerSessionModelInstance;
    [SerializeField] private UIPrefabsConfig _uiPrefabsConfig;
    [SerializeField] private LevelsCollectionProvider _levelsCollectionProvider;
    
    private RootMediator _rootMediator;

    private void Start()
    {
        CommonInstaller.Install(
            _topUICanvasTransform, 
            _uiCanvasTransform,
            _gameRootTransform, 
            _playerSessionModelInstance,
            _uiPrefabsConfig);
        
        _rootMediator = new RootMediator();
        _rootMediator.Mediate();
        
        Resolver.Resolve<PlayerSessionModel>().Reset();
        Resolver.Resolve<PlayerSessionModel>().SetGameState(GameState.MainMenu);
    }

    private void OnDestroy()
    {
        _rootMediator.Unmediate();
    }
}
