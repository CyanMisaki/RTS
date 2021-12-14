using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandRealisation
{
    public class SetRallyCommand : ISetRallyPointCommand
    {
        
        public Vector3 RallyPoint { get; }
        public SetRallyCommand(Vector3 pos) => RallyPoint=pos;

        
    }
}