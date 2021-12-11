using System;
using Utils;

namespace Core
{
    public abstract class BaseAwaiter<T> : IAwaiter<T>
    {
        private Action _continuation;
        private T _result;
        private bool _isCompleted;
        public bool IsCompleted { get; }


        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
                continuation?.Invoke();
            else _continuation = continuation;
        }

        public virtual T GetResult() => _result;
    }
}