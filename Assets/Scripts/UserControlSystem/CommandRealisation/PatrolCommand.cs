using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandRealisation
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 Waypoint { get; set; }

        public PatrolCommand(Vector3 position) => Waypoint = position;

    }
}