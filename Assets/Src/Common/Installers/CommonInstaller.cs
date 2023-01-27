﻿using SimpleDI;
using Src.Common.Providers;
using UnityEngine;

namespace Src.Common.Installers
{
    public static class CommonInstaller
    {
        public static void Install(
            RectTransform topUiCanvasTransform, RectTransform uiCanvasTransform, 
            Transform gameRoot, PlayerSessionModel playerSessionModel,
            UIPrefabsConfig uiPrefabsConfig)
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
        }
    }
}