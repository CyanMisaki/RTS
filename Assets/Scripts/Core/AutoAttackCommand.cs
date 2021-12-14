using Abstractions;
using Abstractions.Commands.CommandsInterfaces;

namespace Core
{
    public class AutoAttackCommand: IAttackCommand
    {
        public IAttackable Enemy { get; set; }

        public AutoAttackCommand(IAttackable enemy)
        {
            Enemy = enemy;
        }

        
    }
    
}