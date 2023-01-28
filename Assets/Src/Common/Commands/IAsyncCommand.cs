using Cysharp.Threading.Tasks;

namespace Src.Common.Commands
{
    public interface IAsyncCommand
    {
        UniTask<bool> ExecuteAsync();
    }
}