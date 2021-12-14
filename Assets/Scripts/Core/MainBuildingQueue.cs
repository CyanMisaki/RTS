using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainBuildingQueue : MonoBehaviour, ICommandsQueue
    {
        public ICommand CurrentCommand => default;
        
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyCommandExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setRallyCommandExecutor.TryExecuteCommand(command);
        }
    }
}