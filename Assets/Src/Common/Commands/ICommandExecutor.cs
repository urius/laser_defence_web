using Cysharp.Threading.Tasks;

namespace Src.Common.Commands
{
    public interface ICommandExecutor
    {
        UniTask<bool> ExecuteAsync<T>() where T : IAsyncCommand, new();
        UniTask<bool> ExecuteAsync<T, TArg>(TArg argument) where T : IAsyncCommand<TArg>, new();
    }
}