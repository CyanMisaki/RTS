using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Model.CommandCreator
{
    public class UIViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ButtonCenterView>()
                .FromComponentInHierarchy().AsSingle();
        }
    }
}