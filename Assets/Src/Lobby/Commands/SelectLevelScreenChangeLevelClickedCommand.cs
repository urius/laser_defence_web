using Cysharp.Threading.Tasks;
using SimpleDI;
using Src.Common.Commands;
using Src.Lobby.Events;

namespace Src.Lobby.Commands
{
    public class SelectLevelScreenChangeLevelClickedCommand : IAsyncCommand<SelectLevelScreenChangeLevelClickedEvent>
    {
        public UniTask<bool> ExecuteAsync(SelectLevelScreenChangeLevelClickedEvent data)
        {
            var sessionModel = Resolver.Resolve<PlayerSessionModel>();
            
            sessionModel.SelectedLevelData.SetSelectedLevelIndex(sessionModel.SelectedLevelIndex + data.Direction);

            return UniTask.FromResult(true);
        }
    }
}