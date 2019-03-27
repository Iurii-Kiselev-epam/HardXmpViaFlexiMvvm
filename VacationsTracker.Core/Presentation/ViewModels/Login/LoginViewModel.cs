using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using System;
using VacationsTracker.Core.Navigation;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private string _login;
        private string _password;

        public event EventHandler LoginFailed = delegate { };

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Login
        {
            get => _login;
            set => SetValue(ref _login, value);
        }
        public string Password
        {
            get => _password;
            set => SetValue(ref _password, value);
        }

        public Command SignInCommand => CommandProvider.Get(SignIn);

        private void SignIn()
        {
            if (string.IsNullOrWhiteSpace(Login)
                || string.IsNullOrWhiteSpace(Password))
            {
                // TODO: include fluent validation
                // ...
            }

            // TODO: if login succeeded navigate to the next screen else raise event
            LoginFailed?.Invoke(this, EventArgs.Empty); // simulate login failed now to show notify window
        }

        public override void Initialize()
        {
            base.Initialize();

            //TODO login view initialization
        }
    }
}
