//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.DashboardViewModelBase.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Tickinator.Model;
using Tickinator.Repository;
using Tickinator.ViewModel.Core;

namespace Tickinator.ViewModel.Dashboard
{
    public abstract class DashboardViewModelBase : ViewModelBase, IDashboardViewModel
    {
        protected DashboardViewModelBase(ITicketRepository ticketRepository)
        {
            Repository = ticketRepository;
        }

        public int OpenTicketCount
        {
            get
            {
                return GetOpenTickets().Count();
            }
        }

        public int ClosedTodayCount
        {
            get
            {
                return GetTodaysClosedTickets().Count();
            }
        }

        public TimeSpan AverageTicketDuration
        {
            get
            {
                var averageDuration = CalculateAverageDuration();
                return TimeSpan.FromMilliseconds(averageDuration);
            }
        }

        protected ITicketRepository Repository { get; private set; }

        protected abstract IEnumerable<Ticket> GetOpenTickets();

        protected abstract IEnumerable<Ticket> GetTodaysClosedTickets();

        double CalculateAverageDuration()
        {
            if (!GetTodaysClosedTickets().Select(p => p.DateClosed - p.DateOpened).Any(p => p.HasValue))
                return 0;

            var ticketDurations =
                GetTodaysClosedTickets().Select(p => p.DateClosed - p.DateOpened).Where(p => p.HasValue);
            var averageDuration = 0.0;

            averageDuration = ticketDurations.Average(p => p.Value.TotalMilliseconds);
            return averageDuration;
        }
    }
}