//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.CanExecuteBase.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Command
{
    public abstract class CanExecuteBase : ICanExecute
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            var canExecuteChanged = CanExecuteChanged;
            if (canExecuteChanged != null)
                canExecuteChanged(this, EventArgs.Empty);
        }
    }
}