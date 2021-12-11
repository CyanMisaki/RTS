using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace Core.CommandExecutors
{
    public class SetRallyPointExecutor : CommandExecutorBase<ISetRallyPointCommand>
    {
        public override void ExecuteSpecificCommand(ISetRallyPointCommand command)
        {
            GetComponent<ProduceUnitCommandExecutor>().SetRallyPoint(command.RallyPoint);
        }
    }
}