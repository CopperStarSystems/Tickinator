using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace Tickinator.ViewModel
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; }
        public ICommand CloseCommand { get; }
    }
}