//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IDashboardViewModel.cs
// 2016/11/25
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Dashboard
{
    public interface IDashboardViewModel : IViewModel
    {
        int OpenTicketCount { get; }

        int ClosedTodayCount { get; }

        TimeSpan AverageTicketDuration { get; }
    }
}