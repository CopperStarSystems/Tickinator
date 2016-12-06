﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.CanExecuteBase.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Command.Core
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