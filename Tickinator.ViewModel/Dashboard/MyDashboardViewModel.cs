﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MyDashboardViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Common;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Dashboard
{
    public class MyDashboardViewModel : DashboardViewModelBase, IMyDashboardViewModel
    {
        readonly ICurrentUserViewModel currentUserViewModel;

        public MyDashboardViewModel(ITicketRepository ticketRepository, ICurrentUserViewModel currentUserViewModel)
            : base(ticketRepository, Strings.Dashboard.MyDashboardTitle)
        {
            this.currentUserViewModel = currentUserViewModel;
        }

        protected override IEnumerable<Ticket> GetOpenTickets()
        {
            return Repository.GetAll().Where(p => p.AssignedToId == currentUserViewModel.Id && !p.DateClosed.HasValue);
        }

        protected override IEnumerable<Ticket> GetTodaysClosedTickets()
        {
            return
                Repository.GetAll()
                          .Where(
                              p =>
                                  p.DateClosed.HasValue && (p.DateClosed.Value == DateTime.Today) &&
                                  (p.AssignedToId == currentUserViewModel.Id));
        }
    }
}