using Tickinator.ViewModel;
using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;
using Tickinator.ViewModel.View.Core;

namespace Tickinator.UI.Wpf.Bootstrap
{
    public class ApplicationLauncher : IApplicationLauncher
    {
        private readonly ICurrentUserViewModelFactory currentUserViewModelFactory;
        private readonly ILoginViewModelFactory loginViewModelFactory;
        private readonly IMainViewModelFactory mainViewModelFactory;
        private readonly IViewFactory viewFactory;

        public ApplicationLauncher(IViewFactory viewFactory, ICurrentUserViewModelFactory currentUserViewModelFactory,
            IMainViewModelFactory mainViewModelFactory, ILoginViewModelFactory loginViewModelFactory)
        {
            this.viewFactory = viewFactory;
            this.currentUserViewModelFactory = currentUserViewModelFactory;
            this.mainViewModelFactory = mainViewModelFactory;
            this.loginViewModelFactory = loginViewModelFactory;
        }

        public void Launch()
        {
            var currentUser = Login();


            if (currentUser != null)
                ShowMainWindow(currentUser);
        }

        private void ShowMainWindow(ICurrentUserViewModel currentUser)
        {
            var mainViewModel = mainViewModelFactory.Create(currentUser);
            var mainView = viewFactory.Create<IMainWindow>();
            mainView.DataContext = mainViewModel;
            mainView.Show();
        }

        private ICurrentUserViewModel Login()
        {
            var view = viewFactory.Create<ILoginView>();
            var viewModel = loginViewModelFactory.Create(view);
            view.DataContext = viewModel;
            view.ShowDialog();
            return null;
        }
    }
}