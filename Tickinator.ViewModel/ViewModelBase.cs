//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ViewModelBase.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tickinator.ViewModel.Annotations;

namespace Tickinator.ViewModel
{
    public abstract class ViewModelBase : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}