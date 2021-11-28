using System;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandRealisation;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public sealed class MoveCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveCommand(argument);
       
    }
}