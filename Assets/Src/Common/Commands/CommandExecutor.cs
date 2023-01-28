using Cysharp.Threading.Tasks;

namespace Src.Common.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        public UniTask<bool> ExecuteAsync<T>() where T : IAsyncCommand, new()
        {
           return new T().ExecuteAsync();
        }
    }
}