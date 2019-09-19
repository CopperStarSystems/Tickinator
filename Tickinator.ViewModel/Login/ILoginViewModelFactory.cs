using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Login
{
    public interface ILoginViewModelFactory
    {
        ILoginViewModel Create(IClosable closable);
    }
}