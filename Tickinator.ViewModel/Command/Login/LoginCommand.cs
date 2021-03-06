﻿using System.ComponentModel;
using System.Linq;
using Tickinator.Repository;
using Tickinator.ViewModel.Command.Core;
using Tickinator.ViewModel.Login;
using Tickinator.ViewModel.User;
using Tickinator.ViewModel.View;

namespace Tickinator.ViewModel.Command.Login
{
    public class LoginCommand : CommandBase, ILoginCommand
    {
        private readonly ICurrentUserViewModelFactory currentUserViewModelFactory;
        private readonly ILoginViewModel loginViewModel;
        private readonly IUserRepository userRepository;
        private readonly IClosable view;

        public LoginCommand(ILoginViewModel loginViewModel, IUserRepository userRepository,
            ICurrentUserViewModelFactory currentUserViewModelFactory, IClosable view)
        {
            this.loginViewModel = loginViewModel;
            loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged
                ;
            this.userRepository = userRepository;
            this.currentUserViewModelFactory = currentUserViewModelFactory;
            this.view = view;
        }

        public override void Execute(object parameter)
        {
            var user = userRepository.GetAll().FirstOrDefault(p =>
                p.UserName.ToLower() == loginViewModel.UserName.ToLower() && p.Password == loginViewModel.Password);
            if (user != null)
            {
                loginViewModel.CurrentUser = currentUserViewModelFactory.Create(user.Id);
                view.Close();
                return;
            }

            loginViewModel.ShowLoginFailure = true;
            loginViewModel.UserName = string.Empty;
            loginViewModel.Password = string.Empty;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(loginViewModel.UserName) && !string.IsNullOrEmpty(loginViewModel.Password);
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (UserNameOrPasswordChanged(e))
                RaiseCanExecuteChanged();
        }

        private bool UserNameOrPasswordChanged(PropertyChangedEventArgs e)
        {
            return e.PropertyName == nameof(loginViewModel.UserName) ||
                   e.PropertyName == nameof(loginViewModel.Password);
        }
    }
}