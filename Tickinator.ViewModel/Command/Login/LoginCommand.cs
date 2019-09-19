using System.Linq;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.User;

namespace Tickinator.ViewModel.Command.Login
{
    public class LoginCommand : CommandBase, ILoginCommand
    {
        private readonly ICurrentUserViewModelFactory currentUserViewModelFactory;
        private readonly ILoginViewModel loginViewModel;
        private readonly IUserRepository userRepository;

        public LoginCommand(ILoginViewModel loginViewModel, IUserRepository userRepository,
            ICurrentUserViewModelFactory currentUserViewModelFactory)
        {
            this.loginViewModel = loginViewModel;
            this.userRepository = userRepository;
            this.currentUserViewModelFactory = currentUserViewModelFactory;
        }

        public override void Execute(object parameter)
        {
            var user = userRepository.GetAll().FirstOrDefault(p =>
                p.UserName.ToLower() == loginViewModel.UserName.ToLower() && p.Password == loginViewModel.Password);
            if (user != null)
                loginViewModel.CurrentUser = currentUserViewModelFactory.Create(user.Id);
        }
    }
}