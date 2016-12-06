//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.CommandBase.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;
using System.Windows.Input;

namespace Tickinator.ViewModel.Command.Core
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}