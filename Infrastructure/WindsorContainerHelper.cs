//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.WindsorContainerHelper.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System.Linq;
using Castle.MicroKernel.ModelBuilder.Inspectors;
using Castle.Windsor;

namespace Tickinator.UI.Wpf.Infrastructure
{
    public static class WindsorContainerHelper
    {
        public static void DisableDefaultPropertyInjectionBehavior(IWindsorContainer container)
        {
            var propertyInjector =
                container.Kernel.ComponentModelBuilder.Contributors.OfType<PropertiesDependenciesModelInspector>()
                         .Single();
            container.Kernel.ComponentModelBuilder.RemoveContributor(propertyInjector);
        }
    }
}