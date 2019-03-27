using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using System;
using System.Windows.Input;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private string _login;
        private string _loginError;
        private string _password;
        private string _passwordError;
        private bool _errorMessageVisible;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Login
        {
            get => _login;
            set => SetValue(ref _login, value);
        }

        public string LoginError
        {
            get => _loginError;
            set => SetValue(ref _loginError, value);
        }

        public string Password
        {
            get => _password;
            set => SetValue(ref _password, value);
        }

        public string PasswordError
        {
            get => _passwordError;
            set => SetValue(ref _passwordError, value);
        }

        public bool ErrorMessageVisible
        {
            get => _errorMessageVisible;
            set => SetValue(ref _errorMessageVisible, value);
        }

        public string ErrorMessage { get; }
            = "Please, retry your login and password pair. Check current Caps Lock and input language settings";

        public ICommand SignInCommand => CommandProvider.Get(SignIn);

        private void SignIn()
        {
            if (string.IsNullOrWhiteSpace(Login)
                || string.IsNullOrWhiteSpace(Password))
            {
                // TODO: include fluent validation
                // ...
            }
            ErrorMessageVisible = true; // show error message in view
        }

        public override void Initialize()
        {
            base.Initialize();

            //TODO login view initialization
        }
    }
}
