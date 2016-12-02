//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.AssemblyInstallerBase.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;
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

        Type[] GetFactoryTypesForAssembly()
        {
            // This is an example of convention-based registration.  We ask the assembly
            // for all interface types whose name ends in "Factory".
            var assembly = Assembly.Load(AssemblyName);
            return assembly.GetTypes().Where(p => p.IsInterface && p.Name.EndsWith("Factory")).ToArray();
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

        void RegisterFactories()
        {
            var factories = GetFactoryTypesForAssembly();

            RegisterTypesAsFactories(factories);
        }

        void RegisterTypesAsFactories(IEnumerable<Type> factories)
        {
            foreach (var factory in factories)
                Container.Register(Component.For(factory).AsFactory());
        }
    }
}