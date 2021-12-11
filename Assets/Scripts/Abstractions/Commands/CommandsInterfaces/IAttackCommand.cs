using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IAttackCommand : ICommand
    {
        IAttackable Enemy { get; set; }
    }
}