//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TeamDashboardViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public class TeamDashboardViewModel : ViewModelBase, ITeamDashboardViewModel
    {
        readonly ITicketRepository ticketRepository;

        public TeamDashboardViewModel(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
    }
}