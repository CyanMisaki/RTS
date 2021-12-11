using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandRealisation;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public sealed class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback) 
            => creationCallback?.Invoke(_context.Inject(new ProduceUnitCommand()));
    }
}