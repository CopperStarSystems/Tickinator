using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.Command.Login;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Login
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        private string password;
        private bool showLoginFailure;
        private string userName;

        public LoginViewModel(ICloseCommandFactory closeCommandFactory, IClosable closable,
            ICurrentUserViewModelFactory currentUserViewModelFactory, ILoginCommandFactory loginCommandFactory)
        {
            CloseCommand = closeCommandFactory.Create(closable);
            LoginCommand = loginCommandFactory.Create(this, closable);
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand CloseCommand { get; }
        public ICurrentUserViewModel CurrentUser { get; set; }

        public bool ShowLoginFailure
        {
            get => showLoginFailure;
            set
            {
                showLoginFailure = value;
                RaisePropertyChanged(nameof(ShowLoginFailure));
            }
        }
    }
}