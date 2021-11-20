using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IMoveCommand : ICommand
    {
        Vector3 Position { get; set; }
    }
}