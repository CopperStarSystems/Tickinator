using System.Windows.Input;

namespace Tickinator.ViewModel
{
    public interface ILoginViewModel : IViewModel
    {
        string UserName { get; set; }
        string Password { get; set; }
        ICommand LoginCommand { get; }

        ICommand CloseCommand { get; }
    }
}