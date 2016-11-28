﻿//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.Dashboard;

namespace Tickinator.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel, IMyDashboardViewModel myDashboardViewModel)
        {
            TeamDashboardViewModel = teamDashboardViewModel;
            MyDashboardViewModel = myDashboardViewModel;
        }

        public ITeamDashboardViewModel TeamDashboardViewModel { get; }
        public IMyDashboardViewModel MyDashboardViewModel { get; }
    }
}