using System;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core.CommandExecutors;
using UnityEngine;
using UserControlSystem.CommandRealisation;


namespace Core
{
    public sealed class Units : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
      
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] EnvironmentType _type;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        [SerializeField] private int _damage = 25;
        [SerializeField] private float _visionRadius = 8f;
       
        private float _health = 100;
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public EnvironmentType Type => _type;
        public int Damage => _damage;
        public float VisionRadius => _visionRadius;
        
        public void ReceiveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                _animator.SetTrigger("PlayDead");
                Invoke(nameof(Destroy), 1f);
            }
        }

        private async void Destroy()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }
    }
}