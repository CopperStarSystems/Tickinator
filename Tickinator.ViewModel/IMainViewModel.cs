//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IMainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Windows.Input;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel
{
    public interface IMainViewModel : IViewModel
    {
        IMyDashboardViewModel MyDashboardViewModel { get; }

        ICommand NewTicketCommand { get; }

        ITeamDashboardViewModel TeamDashboardViewModel { get; }

        ITicketListViewModel TodaysTicketsViewModel { get; }
    }
}