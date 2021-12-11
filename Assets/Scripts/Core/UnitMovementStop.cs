using System;
using Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public event Action OnStop;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private OnCollisionStopper _collisionStopper;
        [SerializeField] private int _throttleFrames = 30;
        [SerializeField] private int _continuityThreshold = 10;


        private void Awake()
        {
            _collisionStopper.Collisions
                .Where(_ => _agent.hasPath)
                .Where(collision => collision.collider.GetComponentInParent<IUnit>() != null)
                .Select(_ => Time.frameCount)
                .Distinct()
                .Buffer(_throttleFrames)
                .Where(buffer =>
                {
                    for (var i = 1; i < buffer.Count; i++)
                    {
                        if (buffer[i] - buffer[i - 1] > _continuityThreshold)
                        {
                            return false;
                        }    
                    }
                    return true;
                })
                .Subscribe(_ =>
                {
                    _agent.isStopped = true;
                    _agent.ResetPath();
                    OnStop?.Invoke();
                })
                .AddTo(this);
        }


        private void Update()
        {
            if (_agent.pathPending) return;

            if (_agent.remainingDistance > _agent.stoppingDistance) return;

            if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
            {
                OnStop?.Invoke();
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);

    }
}