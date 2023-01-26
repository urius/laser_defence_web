using Cysharp.Threading.Tasks;
using Src.Common.View;

namespace Src.Lobby.Views
{
    public interface ILobbyScreenMediator : IMediator
    {
        UniTask ShowAsync();
        UniTask HideAsync();
    }
}