using System.Windows.Input;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Login
{
    public interface ILoginViewModel : IViewModel
    {
        string UserName { get; set; }
        string Password { get; set; }
        ICommand LoginCommand { get; }

        ICommand CloseCommand { get; }

        ICurrentUserViewModel CurrentUser { get; set; }
    }
}