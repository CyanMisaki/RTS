using System;
using Abstractions;
using UnityEngine;
using UserControlSystem.UI.Model;

namespace Utils
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "RTS/" + nameof(AttackableValue), order = 0)]
    public sealed class AttackableValue : StatelessScriptableObjectBase<IAttackable>
    {
        
    }
}