//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.ISelectedItem.cs
// 2016/12/06
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Infrastructure
{
    public interface ISelectedItem<T>
    {
        event EventHandler SelectedItemChanged;

        T SelectedItem { get; set; }
    }
}