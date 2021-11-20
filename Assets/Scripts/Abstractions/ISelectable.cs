﻿using UnityEngine;


namespace Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        string Name { get; }
        EnvironmentType Type { get; }
        Outline Outline { get; }
    }
}
