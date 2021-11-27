using System;

namespace UserControlSystem.UI.Model
{
    public abstract class ScriptableObjectBase<T> where T : Type
    {
        public T CurrentValue { get; private set; }
        
        public event Action<T> OnNewValue;
        
        public virtual void SetValue(T value) 
        {
                CurrentValue = value;
                OnNewValue?.Invoke(value);
        }
    }
}