//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TeamDashboardViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public class TeamDashboardViewModel : DashboardViewModelBase, ITeamDashboardViewModel
    {
        public TeamDashboardViewModel(ITicketRepository ticketRepository) : base(ticketRepository)
        {
        }

        protected override IEnumerable<Ticket> GetOpenTickets()
        {
            return Repository.GetAll().Where(p => !p.DateClosed.HasValue);
        }

        protected override IEnumerable<Ticket> GetTodaysClosedTickets()
        {
            return Repository.GetAll().Where(p => p.DateClosed.HasValue && (p.DateClosed.Value == DateTime.Today));
        }
    }
}