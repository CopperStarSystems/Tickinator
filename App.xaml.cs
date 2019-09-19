//  --------------------------------------------------------------------------------------
// Tickinator.UI.Wpf.App.xaml.cs
// 2016/11/23
//  --------------------------------------------------------------------------------------

using System.Windows;
using Castle.Windsor;
using Tickinator.UI.Wpf.Bootstrap;
using Tickinator.ViewModel;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.UI.Wpf
{
    // Important overall note:
    // In this class you will see several instances of us directly asking
    // the WindsorContainer for types.  This is normal during the bootstrapping
    // phase, but should be avoided elsewhere.  For example, if a ViewModel needs
    // to create instances of some entity type, don't make the ViewModel take a 
    // dependency on the container, instead create a factory interface to create
    // the entities.
    //
    // Passing the container around is basically the ServiceLocator antipattern:
    // http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/
    public partial class App : Application
    {
        IWindsorContainer container;

        // This is the entry point for the application.
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // The process of configuring a Windsor container is known as
            // bootstrapping.  Since it is a Windsor-specific detail, we 
            // isolate that functionality in the Bootstrapper class.
            container = Bootstrapper.Bootstrap();
            var viewFactory = container.Resolve<IViewFactory>();
            var mainViewModel = CreateMainViewModel();
            // Ask the container for an instance of IMainView
            var mainView = viewFactory.Create<IMainWindow>();
            mainView.DataContext = mainViewModel;
            mainView.Show();
        }

        IMainViewModel CreateMainViewModel()
        {
            // Temporarily preserved for comparison purposes:
            //
            // If this looks like a pain to you, congratulations, you're right!
            // Normally an IoC container would take care of all this newing and
            // injecting for us, but we're going with a manual approach at first.
            // var ticketRepository = new TicketRepository();
            // var teamDashboardViewModel = new TeamDashboardViewModel(ticketRepository);
            // var currentUser = new CurrentUserViewModel(1);
            // var myDashboardViewModel = new MyDashboardViewModel(ticketRepository, currentUser);
            // var ticketListItemViewModelFactory = new TicketListItemViewModelFactory();
            // var showTicketDetailsCommand = new ShowTicketDetailsCommand();
            // var todaysTicketsViewModel = new TicketListViewModel(ticketRepository, ticketListItemViewModelFactory,
            //    showTicketDetailsCommand);

            //var mainViewModel = new MainViewModel(teamDashboardViewModel, myDashboardViewModel, todaysTicketsViewModel);

            // ================ Windsor implementation below ================

            // This is still a little bit clunky, but way better than the awfulness above :)
            // Basically anything else we end up creating will just happen like magic,
            // without us having to change this code (in contrast to above, where every single time we 
            // added a new dependency, we had to come add it here, figure out how to propagate it, etc.)
            //
            // Ask the container for an instance of ICurrentUserViewModelFactory
            // (this is a Windsor factory, so we don't actually have a class that implements
            // this interface - Windsor dynamically creates one at runtime when the factory interface is resolved.)
            var currentUserFactory = container.Resolve<ICurrentUserViewModelFactory>();

            // Get an instance of ICurrentUserViewModel from the factory, injecting a 
            // dummy userId of 1.
            var currentUser = currentUserFactory.Create(1);

            // Ask the container for an instance of IMainViewModelFactory
            var mainViewModelFactory = container.Resolve<IMainViewModelFactory>();

            // Get an instance of IMainViewModel from the factory, injecting the currentUser
            // we created above.
            // NOTE:  
            // This is the MainViewModel constructor:
            // public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel, IMyDashboardViewModelFactory myDashboardViewModelFactory, ITicketListViewModel todaysTicketsListViewModel,ICurrentUserViewModel currentUserViewModel)
            // 
            // Windsor automatically resolves all of the dependencies with the exception of ICurrentUser
            // because CurrentUser requires a value injected at runtime (this is why we use a factory to create it) -
            // we inject the value using the ICurrentUserFactory, get an instance, and then inject that instance into MainViewModel
            // using IMainViewModelFactory.
            var mainViewModel = mainViewModelFactory.Create(currentUser);
            return mainViewModel;
        }
    }
}