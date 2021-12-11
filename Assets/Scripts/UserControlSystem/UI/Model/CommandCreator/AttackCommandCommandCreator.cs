using System;
using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandRealisation;
using UserControlSystem.UI.Model.CommandCreator;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public sealed class AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);

    }
}

