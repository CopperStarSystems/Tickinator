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

        public override int OpenTicketCount
        {
            get
            {
                return Repository.GetAll().Count();
            }
        }

        public override int ClosedTodayCount
        {
            get
            {
                return GetTicketsClosedToday().Count();
            }
        }

        public override TimeSpan AverageTicketDuration
        {
            get
            {
                if (!GetTicketsClosedToday().Select(p => p.DateClosed - p.DateOpened).Any(p => p.HasValue))
                    return TimeSpan.Zero;

                var averageDuration = CalculateAverageDuration();
                return TimeSpan.FromMilliseconds(averageDuration);
            }
        }

        double CalculateAverageDuration()
        {
            var ticketDurations = GetTicketsClosedToday()
                .Select(p => p.DateClosed - p.DateOpened)
                .Where(p => p.HasValue);
            var averageDuration = 0.0;

            averageDuration = ticketDurations.Average(p => p.Value.TotalMilliseconds);
            return averageDuration;
        }

        IEnumerable<Ticket> GetTicketsClosedToday()
        {
            return Repository.GetAll().Where(p => p.DateClosed.HasValue && (p.DateClosed.Value == DateTime.Today));
        }
    }
}