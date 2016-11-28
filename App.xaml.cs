using System.Windows;
using Tickinator.Repository.MockData;
using Tickinator.ViewModel;
using Tickinator.ViewModel.Dashboard;
using Tickinator.ViewModel.TicketList;
using Tickinator.ViewModel.User;

namespace Tickinator.UI.Wpf
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // This is the entry point for the application.  Normally
            // we would bootstrap our Inversion of Control (IoC) container
            // here and then launch the main window.
            //
            // Until we integrate an IoC container, we will do this process
            // manually.

            var mainViewModel = CreateMainViewModel();
            var mainView = new MainWindow {DataContext = mainViewModel};
            mainView.Show();
        }

        static MainViewModel CreateMainViewModel()
        {
            // If this looks like a pain to you, congratulations, you're right!
            // Normally an IoC container would take care of all this newing and
            // injecting for us, but we're going with a manual approach at first.
            var ticketRepository = new TicketRepository();
            var teamDashboardViewModel = new TeamDashboardViewModel(ticketRepository);
            var currentUser = new CurrentUserViewModel(1);
            var myDashboardViewModel = new MyDashboardViewModel(ticketRepository, currentUser);
            var todaysTicketsViewModel = new TodaysTicketsListViewModel(ticketRepository);
            var mainViewModel = new MainViewModel(teamDashboardViewModel, myDashboardViewModel, todaysTicketsViewModel);
            return mainViewModel;
        }
    }
}