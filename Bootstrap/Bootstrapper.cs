//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.Bootstrapper.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Tickinator.UI.Wpf.Infrastructure;

namespace Tickinator.UI.Wpf.Bootstrap
{
    // This class has the responsibility of kicking off the Windsor registration process.
    // Once the Bootstrap() method returns, the container is configured and
    // can be used to resolve types.
    public static class Bootstrapper
    {
        public static IWindsorContainer Bootstrap()
        {
            // Create an IWindsorContainer instance, also including the Typed Factory Facility.
            // Facilities are a means of extending Castle Windsor behavior, there are a few that
            // come 'in the box', and users can implement their own facilities also.
            //
            // The TypedFactoryFacility is what enables us to register factory interfaces
            // and have Windsor automatically generate corresponding factory classes for us
            // at runtime.
            var container = new WindsorContainer().AddFacility<TypedFactoryFacility>();

            // By default, Windsor will also resolve property dependencies (i.e. it will 
            // inject default values into properties).  This behavior can cause some interesting
            // issues, and it's only very rarely useful, so we'll tell the container to
            // turn off this behavior.
            WindsorContainerHelper.DisableDefaultPropertyInjectionBehavior(container);

            // And here is where the magic happens...
            // Container.Install kicks off the actual type registration process, and it works like this:
            //
            // FromAssembly.This() tells the container "Hey container, I want you to look at the current
            // assembly and find any and all classes that implement IWindsorInstaller.  Once you've done that,
            // call the "Install" method on each of them."  In our implementation, we have
            // one installer for each dependent assembly.  
            return container.Install(FromAssembly.This());
        }
    }
}