using System;
using Abstractions;
using UnityEngine;


namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "RTS/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : ScriptableObject
    {
        [SerializeField] private Color _selectedOutlineColor;
        [SerializeField] private Color _notSelectedOutlineColor;
        public ISelectable CurrentValue { get; private set; }
        public event Action<ISelectable> OnSelected;

        public void SetValue(ISelectable value)
        {
            if (value == CurrentValue) return;

            OnSelected?.Invoke(value);
        }
    }
}