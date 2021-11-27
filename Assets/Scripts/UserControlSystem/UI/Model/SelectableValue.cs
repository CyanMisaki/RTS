using System;
using Abstractions;
using UnityEngine;


namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "RTS/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public event Action<ISelectable> OnSelected;

        public void SetValue(ISelectable value)
        {
            if (value == CurrentValue) return;
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}