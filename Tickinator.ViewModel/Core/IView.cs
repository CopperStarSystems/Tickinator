//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IView.cs
// 2016/11/29
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.Core
{
    public interface IView
    {
        object DataContext { get; set; }

        void Show();
    }
}