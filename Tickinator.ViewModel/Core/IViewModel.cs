//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Tickinator.ViewModel.Core
{
    // This is just a marker interface identifying ViewModel types
    public interface IViewModel : INotifyPropertyChanged
    {
    }
}