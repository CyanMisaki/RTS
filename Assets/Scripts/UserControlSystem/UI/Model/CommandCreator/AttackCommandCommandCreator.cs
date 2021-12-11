using System;
using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandRealisation;
using UserControlSystem.UI.Model.CommandCreator;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public sealed class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IAttackCommand> _creationCallback;
        
        [Inject]
        private void Init(AttackableValue attackableObjectClicked) => attackableObjectClicked.OnNewValue += OnNewAttackableObject;
        
        private void OnNewAttackableObject(IAttackable attackableObjectClicked)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackableObjectClicked)));
            _creationCallback = null;
        }
        
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
            => _creationCallback = creationCallback;
    }
}

