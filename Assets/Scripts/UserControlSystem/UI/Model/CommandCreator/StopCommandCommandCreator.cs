using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandRealisation;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public sealed class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback) 
            => creationCallback?.Invoke(new StopCommand());
    }
}