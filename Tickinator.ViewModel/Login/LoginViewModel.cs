using System.Windows.Input;
using GalaSoft.MvvmLight;
using Tickinator.ViewModel.Command;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Login
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        public LoginViewModel(ICloseCommandFactory closeCommandFactory, IClosable closable)
        {
            CloseCommand = closeCommandFactory.Create(closable);
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }
        public ICommand CloseCommand { get; }
    }
}