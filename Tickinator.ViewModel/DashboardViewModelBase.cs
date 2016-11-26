//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.DashboardViewModelBase.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;
using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public abstract class DashboardViewModelBase : ViewModelBase, IDashboardViewModel
    {
        protected DashboardViewModelBase(ITicketRepository ticketRepository)
        {
            Repository = ticketRepository;
        }

        public abstract int OpenTicketCount { get; }

        public abstract int ClosedTodayCount { get; }

        public abstract TimeSpan AverageTicketDuration { get; }

        protected ITicketRepository Repository { get; private set; }
    }
}