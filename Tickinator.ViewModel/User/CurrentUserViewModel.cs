//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.CurrentUserViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;

namespace Tickinator.ViewModel.User
{
    public class CurrentUserViewModel : ViewModelBase, ICurrentUserViewModel
    {
        public CurrentUserViewModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}