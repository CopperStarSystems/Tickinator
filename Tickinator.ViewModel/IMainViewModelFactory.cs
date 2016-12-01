//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IMainViewModelFactory.cs
// 2016/11/30
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel
{
    public interface IMainViewModelFactory
    {
        IMainViewModel Create(ICurrentUserViewModel currentUserViewModel);
    }
}