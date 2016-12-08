//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.MockDataAssemblyInstaller.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Castle.MicroKernel.Registration;
using Tickinator.Repository;

namespace Tickinator.UI.Wpf.Bootstrap
{
    // Installs types from the MockData assembly
    public class MockDataAssemblyInstaller : AssemblyInstallerBase
    {
        public MockDataAssemblyInstaller() : base("Tickinator.Repository.MockData")
        {
        }

        protected override void RegisterSingletons()
        {
            base.RegisterSingletons();
            // Register our mock repositories as singletons so that we don't re-initialize
            // our seed data each time a new repository is injected.
            // We probably wouldn't do this in production code, preferring repositories
            // to be transient.
            Container.Register(
                Classes.FromAssemblyNamed(AssemblyName)
                       .BasedOn(typeof(IRepository<>))
                       .WithServiceAllInterfaces()
                       .LifestyleSingleton());
        }
    }
}