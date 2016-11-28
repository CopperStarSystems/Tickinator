//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MyDashboardViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Dashboard
{
    public class MyDashboardViewModel : DashboardViewModelBase, IMyDashboardViewModel
    {
        public MyDashboardViewModel(ITicketRepository ticketRepository) : base(ticketRepository)
        {
        }

        protected override IEnumerable<Ticket> GetOpenTickets()
        {
            return Repository.GetAll().Where(p => p.AssignedToId == 1);
        }

        protected override IEnumerable<Ticket> GetTodaysClosedTickets()
        {
            return
                Repository.GetAll()
                    .Where(p => p.DateClosed.HasValue && (p.DateClosed.Value == DateTime.Today) && (p.AssignedToId == 1));
        }
    }
}