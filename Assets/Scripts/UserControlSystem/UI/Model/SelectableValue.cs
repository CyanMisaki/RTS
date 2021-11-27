using System;
using Abstractions;
using UnityEngine;


namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "RTS/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : ScriptableObjectBase<ISelectable>
    {
        
    }
}