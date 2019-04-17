using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.Core.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IXmpProxy _xmpProxy;
        private string _login;
        private string _loginError;
        private string _password;
        private string _passwordError;
        private string _errorMessage;
        private bool _errorMessageVisible;
        private bool _signInVisible;

        public LoginViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));
            SignInVisible = true;

#if DEBUG
            Login = UserSecrets.Default.Login;
            Password = UserSecrets.Default.Password;
            ErrorMessageVisible = false;
#endif
        }

        public string Login
        {
            get => _login;
            set => ErrorMessageVisible = !SetValue(ref _login, value);
        }

        public string LoginError
        {
            get => _loginError;
            set => SetValue(ref _loginError, value);
        }

        public string Password
        {
            get => _password;
            set => ErrorMessageVisible = !SetValue(ref _password, value);
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

        public bool SignInVisible
        {
            get => _signInVisible;
            set
            {
                SetValue(ref _signInVisible, value);
                RaisePropertyChanged(nameof(ProgressVisible));
            }
        }

        public bool ProgressVisible
        {
            get => !SignInVisible;
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                SetValue(ref _errorMessage, value);
                ErrorMessageVisible = true;
            }
        }

        public ICommand SignInCommand => CommandProvider.GetForAsync(SignIn);

        private async Task SignIn()
        {
            if (string.IsNullOrWhiteSpace(Login)
                || string.IsNullOrWhiteSpace(Password))
            {
                // TODO: include fluent validation
                ErrorMessage = Strings.Invalid_Error_Message;
                await Task.CompletedTask;
                return;
            }

            try
            {
                SignInVisible = false;

                await _xmpProxy.Authenticate(Login, Password);
                _navigationService.NavigateToMainList(this);
            }
            catch(AuthenticationException authExc)
            {
                // TODO: use authExc to log error
                ErrorMessage = Strings.Auth_Error_Message;
                SignInVisible = true;
            }
            catch (CommunicationException cmnExc)
            {
                // TODO: use cmnExc to log error
                ErrorMessage = Strings.Communication_Error_Message;
                SignInVisible = true;
            }
            catch (Exception ex)
            {
                // TODO: use ex to log error
                ErrorMessage = Strings.Unexpected_Error_Message;
                SignInVisible = true;
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            //TODO login view initialization
        }
    }
}
