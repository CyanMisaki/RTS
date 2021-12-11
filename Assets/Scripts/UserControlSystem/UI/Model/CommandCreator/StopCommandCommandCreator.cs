using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandRealisation;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public sealed class StopCommandCommandCreator  : CommandCreatorBase<IStopCommand>
    {
       [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback) 
            => creationCallback?.Invoke(_context.Inject(new StopCommand()));
       
    }
}