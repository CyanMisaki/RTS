using Zenject;

namespace Core
{
    public class CoreInstallser : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
        }
    }
}