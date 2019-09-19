//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.App.xaml.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Windows;
using Castle.Windsor;
using Tickinator.UI.Wpf.Bootstrap;

namespace Tickinator.UI.Wpf
{
    public partial class App : Application
    {
        private IWindsorContainer container;

        // This is the entry point for the application.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // The process of configuring a Windsor container is known as
            // bootstrapping.  Since it is a Windsor-specific detail, we 
            // isolate that functionality in the Bootstrapper class.
            container = Bootstrapper.Bootstrap();
            var launcher = container.Resolve<IApplicationLauncher>();
            launcher.Launch();
        }
    }
}