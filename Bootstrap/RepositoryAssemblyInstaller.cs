//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.RepositoryAssemblyInstaller.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Tickinator.ViewModel;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.Factory;
using Tickinator.ViewModel.User;

namespace Tickinator.UI.Wpf.Bootstrap
{
    // Installs types from the Repository assembly
    public class RepositoryAssemblyInstaller : AssemblyInstallerBase
    {
        public RepositoryAssemblyInstaller() : base("Tickinator.Repository")
        {
        }

        // We don't have automated logic for identifying factory interfaces yet
        // but we need to register several factories so that Windsor can resolve them.
        // For now, this will serve as a reference for how to manually register
        // factory interfaces.
        protected override void RegisterFactories()
        {
            base.RegisterFactories();
            // Register our factory interfaces.  Note the .AsFactory() at the end, that's
            // what configures the specified interface as a factory in Windsor.
            Container.Register(Component.For<ICurrentUserViewModelFactory>().AsFactory());
            Container.Register(Component.For<IMainViewModelFactory>().AsFactory());
            Container.Register(Component.For<ITicketListItemViewModelFactory>().AsFactory());
            Container.Register(Component.For<IComposableCommandFactory>().AsFactory());
            Container.Register(Component.For<IMyDashboardViewModelFactory>().AsFactory());
            Container.Register(Component.For<IViewFactory>().AsFactory());
        }
    }
}