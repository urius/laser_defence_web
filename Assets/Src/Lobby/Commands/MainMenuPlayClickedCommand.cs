using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Commands;
using Src.Common.Model;
using Src.Lobby.Events;

namespace Src.Lobby.Commands
{
    public class MainMenuPlayClickedCommand : IAsyncCommand<MainMenuPlayClickedEvent>
    {
        public UniTask<bool> ExecuteAsync(MainMenuPlayClickedEvent @event)
        {
            var playerSessionModel = Resolver.Resolve<PlayerSessionModel>();
            
            playerSessionModel.SetGameState(GameState.SelectLevelMenu);
            
            return UniTask.FromResult(true);
        }
    }
}