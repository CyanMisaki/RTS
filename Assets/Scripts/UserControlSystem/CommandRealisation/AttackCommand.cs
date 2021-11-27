using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandRealisation
{
    public class AttackCommand : IAttackCommand
    {
       public IAttackable Enemy { get; set; }

        public AttackCommand(IAttackable enemy) => Enemy = enemy;
    }
}