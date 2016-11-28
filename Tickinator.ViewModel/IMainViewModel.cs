//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IMainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.Dashboard;

namespace Tickinator.ViewModel
{
    public interface IMainViewModel : IViewModel
    {
        ITeamDashboardViewModel TeamDashboardViewModel { get; }

        IMyDashboardViewModel MyDashboardViewModel { get; }
    }
}