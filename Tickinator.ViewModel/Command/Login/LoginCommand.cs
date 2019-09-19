using System;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Login;

namespace Tickinator.ViewModel.Command.Login
{
    public class LoginCommand : CommandBase, ILoginCommand
    {
        private readonly ILoginViewModel loginViewModel;

        public LoginCommand(ILoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}