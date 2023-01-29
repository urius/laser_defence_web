using Cysharp.Threading.Tasks;
using Src.Common.Commands;
using Src.Lobby.Events;
using UnityEngine;

namespace Src.Lobby.Commands
{
    public class MainMenuPlayClickedCommand : IAsyncCommand<MainMenuPlayClickedEvent>
    {
        public UniTask<bool> ExecuteAsync(MainMenuPlayClickedEvent @event)
        {
            Debug.Log("MainMenuPlayClickedCommand");

            return UniTask.FromResult(true);
        }
    }
}