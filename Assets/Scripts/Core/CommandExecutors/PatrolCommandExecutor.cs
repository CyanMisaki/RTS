using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

       public override async void ExecuteSpecificCommand(IPatrolCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Waypoint;
            _animator.SetTrigger(Walk);
            await _stop;
            _animator.SetTrigger(Idle);
            
           
        }
    }
}