using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem.CommandRealisation
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [Inject(Id = "Ellen Variant")] public string UnitName { get; }

        [Inject(Id = "Ellen Variant")] public Sprite Icon { get; }

        [Inject(Id = "Ellen Variant")] public float ProductionTime { get; }
        
        [InjectAsset("Ellen Variant")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}