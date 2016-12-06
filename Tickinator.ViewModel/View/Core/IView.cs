//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IView.cs
// 2016/12/02
//  --------------------------------------------------------------------------------------

namespace Tickinator.ViewModel.View.Core
{
    public interface IView : IClosable
    {
        object DataContext { get; set; }

        void Show();

        bool? ShowDialog();
    }
}