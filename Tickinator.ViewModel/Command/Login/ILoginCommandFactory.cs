using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Command.Login
{
    public interface ILoginCommandFactory
    {
        ILoginCommand Create(ILoginViewModel loginViewModel, IClosable view);
    }
}