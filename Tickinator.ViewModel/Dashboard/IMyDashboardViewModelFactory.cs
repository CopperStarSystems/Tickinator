//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IMyDashboardViewModelFactory.cs
// 2016/11/30
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Dashboard
{
    public interface IMyDashboardViewModelFactory
    {
        IMyDashboardViewModel Create(ICurrentUserViewModel currentUserViewModel);
    }
}