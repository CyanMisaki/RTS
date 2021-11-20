using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandRealisation
{
    public class AttackCommand : IAttackCommand
    {
        public GameObject Enemy { get; set; }
        
        public AttackCommand(GameObject enemy) => Enemy = enemy;
    }
}