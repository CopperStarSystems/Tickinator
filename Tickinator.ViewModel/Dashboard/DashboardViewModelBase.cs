//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.DashboardViewModelBase.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using Tickinator.Model;
using Tickinator.Repository;

namespace Tickinator.ViewModel.Dashboard
{
    public abstract class DashboardViewModelBase : ViewModelBase, IDashboardViewModel
    {
        protected DashboardViewModelBase(ITicketRepository ticketRepository, string title)
        {
            Repository = ticketRepository;
            Title = title;
        }

        public string Title { get; }

        public TimeSpan AverageTicketDuration
        {
            get
            {
                var averageDuration = CalculateAverageDuration();
                return TimeSpan.FromMilliseconds(averageDuration);
            }
        }

        public int ClosedTodayCount
        {
            get { return GetTodaysClosedTickets().Count(); }
        }

        public int OpenTicketCount
        {
            get { return GetOpenTickets().Count(); }
        }

        protected abstract IEnumerable<Ticket> GetOpenTickets();

        protected abstract IEnumerable<Ticket> GetTodaysClosedTickets();

        protected ITicketRepository Repository { get; private set; }

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