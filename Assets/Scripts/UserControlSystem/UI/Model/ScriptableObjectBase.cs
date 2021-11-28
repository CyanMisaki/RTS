using System;
using UnityEngine;
using Utils;

namespace UserControlSystem.UI.Model
{
    public abstract class ScriptableObjectBase<T> : ScriptableObject, IAwaitable<T>
    {
        public T CurrentValue { get; private set; }
        
        public event Action<T> OnNewValue;
        
        public void SetValue(T value) 
        {
                CurrentValue = value;
                OnNewValue?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter() => new NewValueNotifier<T>(this);
        


        
        
        
        
        public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
        {
            private readonly ScriptableObjectBase<TAwaited> _scriptableObjectBase;
            private TAwaited _result;
            private Action _continuation;
            private bool _isCompleted;
            
            public bool IsCompleted { get; }

            public NewValueNotifier(ScriptableObjectBase<TAwaited> scriptableObjectBase)
            {
                _scriptableObjectBase = scriptableObjectBase;
                _scriptableObjectBase.OnNewValue += OnNewValue;
            }

            private void OnNewValue(TAwaited obj)
            {
                _scriptableObjectBase.OnNewValue -= OnNewValue;
                _result = obj;
                _isCompleted = true;
                _continuation?.Invoke();
            }

            public void OnCompleted(Action continuation)
            {
                if (_isCompleted)
                    continuation?.Invoke();
                else _continuation = continuation;
            }

            public TAwaited GetResult() => _result;
            
        }


        
    }
}