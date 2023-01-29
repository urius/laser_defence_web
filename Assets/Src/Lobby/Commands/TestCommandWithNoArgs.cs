using Cysharp.Threading.Tasks;
using Src.Common.Commands;
using UnityEngine;

namespace Src.Lobby.Commands
{
    public class TestCommandWithNoArgs : IAsyncCommand
    {
        public UniTask<bool> ExecuteAsync()
        {
            Debug.Log("TestCommandWithNoArgs");

            return UniTask.FromResult(true);
        }
    }
}