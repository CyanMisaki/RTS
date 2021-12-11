using System;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;



namespace Core
{
    public sealed class Units : MonoBehaviour, ISelectable, IAttackable, IUnit
    {
      
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] EnvironmentType _type;
       
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public EnvironmentType Type => _type;
        
        private float _health = 100;

    }
}