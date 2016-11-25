//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TeamDashboardViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Linq;
using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public class TeamDashboardViewModel : DashboardViewModelBase, ITeamDashboardViewModel
    {
        public TeamDashboardViewModel(ITicketRepository ticketRepository) : base(ticketRepository)
        {
        }

        public override int OpenTicketCount
        {
            get
            {
                return Repository.GetAll().Count();
            }
        }
    }
}