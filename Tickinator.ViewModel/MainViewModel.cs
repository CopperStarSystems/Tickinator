//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public IMyDashboardViewModel MyDashboardViewModel { get; }

        public ITeamDashboardViewModel TeamDashboardViewModel { get; }

        public ITicketListViewModel TodaysTicketsViewModel { get; }

        public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel,
                             IMyDashboardViewModelFactory myDashboardViewModelFactory,
                             ITicketListViewModel todaysTicketsListViewModel, ICurrentUserViewModel currentUserViewModel)
        {
            TeamDashboardViewModel = teamDashboardViewModel;
            MyDashboardViewModel = myDashboardViewModelFactory.Create(currentUserViewModel);
            TodaysTicketsViewModel = todaysTicketsListViewModel;
        }
    }
}