using Tickinator.ViewModel.Login;

namespace Tickinator.ViewModel.Command.Login
{
    public interface ILoginCommandFactory
    {
        ILoginCommand Create(ILoginViewModel loginViewModel);
    }
}