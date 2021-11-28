using System;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public event Action OnStop;
        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            if (_agent.pathPending) return;
            if (!(_agent.remainingDistance <= _agent.stoppingDistance)) return;
            
            if(!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                OnStop?.Invoke();
        }
        
        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);


        
        
        
        public class StopAwaiter : IAwaiter<AsyncExtensions.Void>
        {
            private readonly UnitMovementStop _unitMovementStop;
            private Action _continuation;
            private bool _isCompleted;

            public bool IsCompleted => _isCompleted;
            public AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();

            public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                _unitMovementStop = unitMovementStop;
                _unitMovementStop.OnStop += OnStop;
            }

            private void OnStop()
            {
                _unitMovementStop.OnStop -= OnStop;
                _isCompleted = true;
                _continuation?.Invoke();
            }

            public void OnCompleted(Action continuation)
            {
                if (_isCompleted)
                    continuation?.Invoke();
                else _continuation = continuation;
            }
        }
        
        
    }
}