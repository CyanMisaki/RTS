using System;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandRealisation;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public sealed class SetRallyCommandCommandCreator : CancellableCommandCreatorBase<ISetRallyPointCommand,Vector3>
    {
        protected override ISetRallyPointCommand CreateCommand(Vector3 argument) => new SetRallyCommand(argument);
    }
}