//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.TeamDashboardViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Common;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Dashboard
{
    public class TeamDashboardViewModel : DashboardViewModelBase, ITeamDashboardViewModel
    {
        public TeamDashboardViewModel(ITicketRepository ticketRepository) : base(ticketRepository, Strings.Dashboard.TeamDashboardTitle)
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