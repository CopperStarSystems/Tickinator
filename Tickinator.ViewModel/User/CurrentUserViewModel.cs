//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.CurrentUserViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;

namespace Tickinator.ViewModel.User
{
    public class CurrentUserViewModel : ViewModelBase, ICurrentUserViewModel
    {
        public int Id { get; }

        public CurrentUserViewModel(int id)
        {
            Id = id;
        }
    }
}