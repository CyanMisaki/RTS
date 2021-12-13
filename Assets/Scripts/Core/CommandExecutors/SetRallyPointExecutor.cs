using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace Core.CommandExecutors
{
    public class SetRallyPointExecutor : CommandExecutorBase<ISetRallyPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
        {
            GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
        }
    }
}