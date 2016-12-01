//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.ViewModelAssemblyInstaller.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.UI.Wpf.Bootstrap
{
    // Installs types from the ViewModels assembly
    public class ViewModelAssemblyInstaller : AssemblyInstallerBase
    {
        public ViewModelAssemblyInstaller() : base("Tickinator.ViewModel")
        {
        }
    }
}