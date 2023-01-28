using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Commands;
using Src.Common.Installers;
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

    private void Awake()
    {
        CommonInstaller.Install(
            _topUICanvasTransform, 
            _uiCanvasTransform,
            _gameRootTransform, 
            _playerSessionModelInstance,
            _uiPrefabsConfig);

        Resolver.Resolve<PlayerSessionModel>().Reset();
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
