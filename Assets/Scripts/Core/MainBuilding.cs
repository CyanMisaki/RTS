using System.Runtime.CompilerServices;
using Abstractions;
using UnityEngine;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
       

        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private EnvironmentType _type;
        [SerializeField]private Outline _outline;
        

        private float _health = 1000;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public string Name => _name;
        public EnvironmentType Type => _type;
        public Outline Outline => _outline;
        


        public void ProduceUnit()
        {
            Instantiate(_unitPrefab,
                new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                Quaternion.identity, _unitsParent);
        }
    }
}