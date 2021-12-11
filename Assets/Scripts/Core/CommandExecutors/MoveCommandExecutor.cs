using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");
        
        
        private ReactiveCollection<IMoveTask> _queue = new ReactiveCollection<IMoveTask>();
        public IReadOnlyReactiveCollection<IMoveTask> Queue => _queue;
        private Task _currentTask;

        private void Start()
        {
            Observable.EveryUpdate().Subscribe(_ => OnUpdate()).AddTo(this);
        }

        
        private void OnUpdate()
        {
            if (_queue.Count == 0) return;

            var innerTask = (MoveTask) _queue[0];

            if(_currentTask==null)
                _currentTask = SetNextPoint(innerTask);
            else if(_currentTask.IsCompleted)
            {
                RemoveTaskAtIndex(0);
                _currentTask = null;
            }

        }

        public void Init(Vector3 pos)
        {
            _queue.Add(new MoveTask(pos));
        }

        private async Task SetNextPoint(MoveTask innerTask)
        {
            GetComponent<NavMeshAgent>().destination = innerTask.PathPoint;
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
                _queue.Clear();
            }

            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Idle);
        }

        private void RemoveTaskAtIndex(int index)
        {
            for (var i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count-1);
        }
        
        
        
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            _queue.Add(new MoveTask(command.Position));
        }
    }
}