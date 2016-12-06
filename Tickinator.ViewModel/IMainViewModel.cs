//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IMainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel
{
    public interface IMainViewModel : IViewModel
    {
        IMyDashboardViewModel MyDashboardViewModel { get; }
        ITeamDashboardViewModel TeamDashboardViewModel { get; }

        ITicketListViewModel TodaysTicketsViewModel { get; }
    }
}