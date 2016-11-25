//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TeamDashboardViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Linq;
using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public class TeamDashboardViewModel : ViewModelBase, ITeamDashboardViewModel
    {
        readonly ITicketRepository ticketRepository;
        int openTicketCount;

        public TeamDashboardViewModel(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
            OpenTicketCount = ticketRepository.GetAll().Count();
        }

        public int OpenTicketCount
        {
            get
            {
                return openTicketCount;
            }
            set
            {
                openTicketCount = value;
                // RaisePropertyChanged will notify the WPF binding subsystem
                // that it needs to update the UI.
                RaisePropertyChanged(nameof(OpenTicketCount));
            }
        }
    }
}