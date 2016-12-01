//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.AssemblyInstallerBase.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Tickinator.UI.Wpf.Bootstrap
{
    // This is a base class that helps to standardize the assembly installation process.
    // It provides a standardized installation order, along with extension points so that
    // derived classes can override default behavior as needed.
    public abstract class AssemblyInstallerBase : IWindsorInstaller
    {
        protected IWindsorContainer Container;

        protected AssemblyInstallerBase(string assemblyName)
        {
            AssemblyName = assemblyName;
        }

        protected string AssemblyName { get; }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Container = container;
            InstallInternal();
        }

        protected virtual BasedOnDescriptor RegisterAssemblyTypeOverrides(BasedOnDescriptor assemblyRegistration)
        {
            // Passthrough by default, derived classes can override
            return assemblyRegistration;
        }

        protected virtual void RegisterFactories()
        {
            // Do nothing by default (at least for now).  Derived classes
            // that need to register factories will have to do that manually for now.
        }

        void InstallInternal()
        {
            // Register factory interfaces with the container
            RegisterFactories();
            // Register remaining assembly classes
            RegisterAllAssemblyClasses();
        }

        // Register all assembly classes
        void RegisterAllAssemblyClasses()
        {
            var basedOnDescriptor =
                Classes.FromAssemblyNamed(AssemblyName).Pick().WithService.DefaultInterfaces().LifestyleTransient();
            Container.Register(RegisterAssemblyTypeOverrides(basedOnDescriptor));
        }
    }
}