﻿using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface ISetRallyPointCommand : ICommand
    {
        public Vector3 RallyPoint { get; }
    }
}