using SimpleDI;
using Src.Common.Commands;
using Src.Common.Dispatcher;
using Src.Common.Providers;
using UnityEngine;

namespace Src.Common.Installers
{
    public static class CommonInstaller
    {
        public static void Install(RectTransform topUiCanvasTransform, RectTransform uiCanvasTransform,
            Transform gameRoot, PlayerSessionModel playerSessionModel,
            UIPrefabsConfig uiPrefabsConfig, CellConfigProvider cellConfigProvider)
        {
            var rootTransformsProvider = new RootTransformsProvider();
            rootTransformsProvider.Setup(topUiCanvasTransform, uiCanvasTransform, gameRoot);
            
            Binder.Bind<RootTransformsProvider>()
                .As<ITopUiTransformProvider>()
                .As<IUiCanvasTransformProvider>()
                .As<IRootGameTransformProvider>()
                .FromInstance(rootTransformsProvider);
            
            Binder.Bind<PlayerSessionModel>().AsSelf().FromInstance(playerSessionModel);
            Binder.Bind<UIPrefabsConfig>().AsSelf().FromInstance(uiPrefabsConfig);
            Binder.Bind<CellConfigProvider>().AsSelf().FromInstance(cellConfigProvider);

            Binder.Bind<EventDispatcher>()
                .As<IEventDispatcher>()
                .As<IEventListener>()
                .AsSingleton();

            Binder.Bind<EventCommandMapper>().AsSelf().AsSingleton();
            
            Binder.Bind<CommandExecutor, ICommandExecutor>();
        }
    }
}