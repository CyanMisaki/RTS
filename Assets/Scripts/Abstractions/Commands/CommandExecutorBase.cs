using UnityEngine;

namespace Abstractions.Commands
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
    {
        public abstract void ExecuteSpecificCommand(T command);
        public void ExecuteCommand(object command) => ExecuteSpecificCommand((T)command);

        
    }
}