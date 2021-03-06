using System.Threading;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

       public override async void ExecuteSpecificCommand(IPatrolCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Waypoint;
            _animator.SetTrigger(Walk);
            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Idle);
        }
    }
}