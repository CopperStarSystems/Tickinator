//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IMainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel
{
    public interface IMainViewModel : IViewModel
    {
        ITeamDashboardViewModel TeamDashboardViewModel { get; }

        IMyDashboardViewModel MyDashboardViewModel { get; }

        ITicketListViewModel TodaysTicketsViewModel { get; }
    }
}