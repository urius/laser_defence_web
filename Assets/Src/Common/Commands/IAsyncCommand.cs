using Cysharp.Threading.Tasks;

namespace Src.Common.Commands
{
    public interface IAsyncCommand
    {
        UniTask<bool> ExecuteAsync();
    }
    
    public interface IAsyncCommand<in T>
    {
        UniTask<bool> ExecuteAsync(T parameter);
    }
}