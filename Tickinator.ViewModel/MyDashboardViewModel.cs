//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MyDashboardViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;
using Tickinator.Repository;

namespace Tickinator.ViewModel
{
    public class MyDashboardViewModel : DashboardViewModelBase, IMyDashboardViewModel
    {
        public MyDashboardViewModel(ITicketRepository ticketRepository) : base(ticketRepository)
        {
        }

        public override int OpenTicketCount { get; }
        public override int ClosedTodayCount { get; }
        public override TimeSpan AverageTicketDuration { get; }
    }
}