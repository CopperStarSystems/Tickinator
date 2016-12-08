//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.MvvmLightAssemblyInstaller.cs
// 2016/12/08
//  --------------------------------------------------------------------------------------

using Castle.MicroKernel.Registration;
using GalaSoft.MvvmLight.Messaging;

namespace Tickinator.UI.Wpf.Bootstrap
{
    public class MvvmLightAssemblyInstaller : AssemblyInstallerBase
    {
        public MvvmLightAssemblyInstaller() : base("GalaSoft.MvvmLight")
        {
        }

        protected override void RegisterSingletons()
        {
            base.RegisterSingletons();
            Container.Register(Component.For<IMessenger>().ImplementedBy<Messenger>().LifeStyle.Singleton);
        }
    }
}