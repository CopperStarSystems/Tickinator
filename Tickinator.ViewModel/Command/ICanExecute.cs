//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ICanExecute.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Command
{
    public interface ICanExecute
    {
        event EventHandler CanExecuteChanged;
        bool CanExecute(object parameter);
    }
}