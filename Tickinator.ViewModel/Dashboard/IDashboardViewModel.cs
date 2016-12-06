﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.IDashboardViewModel.cs
// 2016/11/28
//  --------------------------------------------------------------------------------------

using System;

namespace Tickinator.ViewModel.Dashboard
{
    public interface IDashboardViewModel : IViewModel
    {
        TimeSpan AverageTicketDuration { get; }

        int ClosedTodayCount { get; }

        int OpenTicketCount { get; }
    }
}