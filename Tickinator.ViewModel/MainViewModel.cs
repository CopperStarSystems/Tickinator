//  --------------------------------------------------------------------------------------
// Tickinator.ViewModel.MainViewModel.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel,
                             IMyDashboardViewModelFactory myDashboardViewModelFactory,
                             ITicketListViewModel todaysTicketsListViewModel, ICurrentUserViewModel currentUserViewModel,
                             INewTicketCommand newTicketCommand)
        {
            TeamDashboardViewModel = teamDashboardViewModel;
            MyDashboardViewModel = myDashboardViewModelFactory.Create(currentUserViewModel);
            TodaysTicketsViewModel = todaysTicketsListViewModel;
            NewTicketCommand = newTicketCommand;
        }

        public IMyDashboardViewModel MyDashboardViewModel { get; }

        public ICommand NewTicketCommand { get; }

        public ITeamDashboardViewModel TeamDashboardViewModel { get; }

        public ITicketListViewModel TodaysTicketsViewModel { get; }
    }
}