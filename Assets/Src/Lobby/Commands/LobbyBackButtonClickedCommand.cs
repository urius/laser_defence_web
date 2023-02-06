using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Commands;
using Src.Common.Model;

namespace Src.Lobby.Commands
{
    public class LobbyBackButtonClickedCommand : IAsyncCommand
    {
        public UniTask<bool> ExecuteAsync()
        {
            var sessionModel = Resolver.Resolve<PlayerSessionModel>();

            switch (sessionModel.GameState)
            {
                case GameState.SelectLevelMenu:
                    sessionModel.SetGameState(GameState.MainMenu);
                    break;
            }

            return UniTask.FromResult(true);
        }
    }
}