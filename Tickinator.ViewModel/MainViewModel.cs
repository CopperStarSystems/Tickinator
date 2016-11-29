//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;
using Tickinator.ViewModel.Core;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;

namespace Tickinator.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel, IMyDashboardViewModel myDashboardViewModel,
            ITodaysTicketsListViewModel todaysTicketsListViewModel)
        {
            TeamDashboardViewModel = teamDashboardViewModel;
            MyDashboardViewModel = myDashboardViewModel;
            TodaysTicketsViewModel = todaysTicketsListViewModel;
        }

        public ITeamDashboardViewModel TeamDashboardViewModel { get; }
        public IMyDashboardViewModel MyDashboardViewModel { get; }
        public ITodaysTicketsListViewModel TodaysTicketsViewModel { get; }
    }
}