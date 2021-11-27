using System;
using Abstractions;
using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "RTS/" + nameof(AttackableValue), order = 0)]
    public sealed class AttackableValue : ScriptableObject
    {
       
        public IAttackable CurrentValue { get; private set; }
        public Action<IAttackable> OnNewAttackableObject;
        public void SetValue(IAttackable value)
        {
            if (value == CurrentValue) return;
            CurrentValue = value;
            OnNewAttackableObject?.Invoke(value);
        } 
    }
}