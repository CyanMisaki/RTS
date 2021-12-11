using System;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using UserControlSystem.CommandRealisation;
using Random = UnityEngine.Random;

namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maxUnitsInQueue;
        

        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();
        private Vector3 _spawnPosition;
        private Vector3 _rallyPoint;
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;
        public Vector3 RallyPoint
        {
            get;
            private set;
        }

        private void Start()
        {
            _spawnPosition=(new Vector3(Random.Range(-1,1),0,Random.Range(-1,1)));
            Observable.EveryUpdate().Subscribe(_ => OnUpdate()).AddTo(this);
        }

        private void OnUpdate()
        {
            if (_queue.Count == 0) return;

            var innerTask = (UnitProductionTask) _queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if(innerTask.TimeLeft<=0)
            {
                RemoveTaskAtIndex(0);
                var newUnit = Instantiate(innerTask.UnitPrefab, _spawnPosition, Quaternion.identity, _unitsParent);
                newUnit.GetComponent<MoveCommandExecutor>().Init(_rallyPoint);
            }
        }
        
        public void Cancel(int index) => RemoveTaskAtIndex(index);
        
        private void RemoveTaskAtIndex(int index)
        {
            for (var i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count-1);
        }

        public void SetRallyPoint(Vector3 point)
        {
            _rallyPoint = point;
        }
        
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            _queue.Add(new UnitProductionTask(command.ProductionTime,command.Icon,command.UnitPrefab,command.UnitName));
        }

        
        
    }
}