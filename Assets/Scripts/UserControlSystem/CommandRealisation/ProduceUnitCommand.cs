using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

namespace UserControlSystem.CommandRealisation
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Ellen Variant")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}