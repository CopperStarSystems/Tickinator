//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.MockDataAssemblyInstaller.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.UI.Wpf.Bootstrap
{
    // Installs types from the MockData assembly
    public class MockDataAssemblyInstaller : AssemblyInstallerBase
    {
        // This is a super-simple installer, it doesn't need any special 
        // functionality, so we can just tell our base class which 
        // assembly to install from and let it handle the rest of the process.
        public MockDataAssemblyInstaller() : base("Tickinator.Repository.MockData")
        {
        }
    }
}