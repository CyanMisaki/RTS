using System;
using UnityEngine;

namespace UserControlSystem.UI.Model
{
    public abstract class ScriptableObjectBase<T> : ScriptableObject
    {
        public T CurrentValue { get; private set; }
        
        public event Action<T> OnNewValue;
        
        public void SetValue(T value) 
        {
                CurrentValue = value;
                OnNewValue?.Invoke(value);
        }
    }
}