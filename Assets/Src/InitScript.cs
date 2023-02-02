using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Commands;
using Src.Common.Installers;
using Src.Common.View;
using Src.Lobby.Commands;
using Src.Lobby.Events;
using UnityEngine;

public class InitScript : MonoBehaviour
{
    [SerializeField] private RectTransform _uiCanvasTransform;
    [SerializeField] private RectTransform _topUICanvasTransform;
    [SerializeField] private Transform _gameRootTransform;
    [SerializeField] private PlayerSessionModel _playerSessionModelInstance;
    [SerializeField] private UIPrefabsConfig _uiPrefabsConfig;
    [SerializeField] private LevelsCollectionProvider _levelsCollectionProvider;
    [SerializeField] private CellConfigProvider _cellConfigProvider;
    
    private RootMediator _rootMediator;

    private void Awake()
    {
        CommonInstaller.Install(
            _topUICanvasTransform, 
            _uiCanvasTransform,
            _gameRootTransform, 
            _playerSessionModelInstance,
            _uiPrefabsConfig,
            _cellConfigProvider);

        MapCommands();

        Resolver.Resolve<PlayerSessionModel>().Reset();
    }

    private void MapCommands()
    {
        var commandMapper = Resolver.Resolve<EventCommandMapper>();
        
        commandMapper.Map<MainMenuPlayClickedEvent, MainMenuPlayClickedCommand>();
        commandMapper.Map<SelectLevelScreenChangeLevelClickedEvent, SelectLevelScreenChangeLevelClickedCommand>();
        //commandMapper.Map<MainMenuPlayClickedEvent, TestCommandWithNoArgs>(); //test
    }

    private void Start()
    {
        _rootMediator = new RootMediator();
        _rootMediator.Mediate();

        StartLoadSequence().Forget();
    }

    private async UniTaskVoid StartLoadSequence()
    {
        var commandExecutor = Resolver.Resolve<ICommandExecutor>();
        var loadResult = await commandExecutor.ExecuteAsync<LoadDataCommand>();
    }

    private void OnDestroy()
    {
        _rootMediator.Unmediate();
    }
}
