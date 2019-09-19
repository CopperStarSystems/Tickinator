using Tickinator.ViewModel;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.UI.Wpf.Bootstrap
{
    public class ApplicationLauncher : IApplicationLauncher
    {
        private readonly ICurrentUserViewModelFactory currentUserViewModelFactory;
        private readonly IMainViewModelFactory mainViewModelFactory;
        private readonly IViewFactory viewFactory;

        public ApplicationLauncher(IViewFactory viewFactory, ICurrentUserViewModelFactory currentUserViewModelFactory,
            IMainViewModelFactory mainViewModelFactory)
        {
            this.viewFactory = viewFactory;
            this.currentUserViewModelFactory = currentUserViewModelFactory;
            this.mainViewModelFactory = mainViewModelFactory;
        }

        public void Launch()
        {
            var currentUser = currentUserViewModelFactory.Create(1);
            var mainViewModel = mainViewModelFactory.Create(currentUser);
            var mainView = viewFactory.Create<IMainWindow>();
            mainView.DataContext = mainViewModel;
            mainView.Show();
        }
    }
}