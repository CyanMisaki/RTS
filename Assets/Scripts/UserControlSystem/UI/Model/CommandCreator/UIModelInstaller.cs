using System;
using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.UI.Presenter;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private Sprite _ellenSprite;
        
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>()
                .To<SetRallyCommandCommandCreator>().AsTransient();
            
            Container.Bind<CommandButtonsModel>().AsTransient();

            Container.Bind<float>().WithId("Ellen Variant").FromInstance(5f);
            Container.Bind<string>().WithId("Ellen Variant").FromInstance("Ellen Variant");
            Container.Bind<Sprite>().WithId("Ellen Variant").FromInstance(_ellenSprite);

            Container.Bind<BottomCenterModel>().AsSingle();
        }
    }
}