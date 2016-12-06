//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ICanExecute.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Command.Core
{
    public interface ICanExecute
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object parameter);
    }
}