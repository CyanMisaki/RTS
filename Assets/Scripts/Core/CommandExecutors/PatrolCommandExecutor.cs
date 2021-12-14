using System;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _unitMovementStop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        
        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            var point1 = transform.position;
            var point2 = command.Waypoint;
            while (true)
            {
                GetComponent<NavMeshAgent>().destination = point2;
                _animator.SetTrigger(Animator.StringToHash("Walk"));
                _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();

                try
                {
                    await _unitMovementStop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
                }
                catch
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();
                    break;
                }

                (point1, point2) = (point2, point1);
            }

            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash("Idle"));
        }
    }
}