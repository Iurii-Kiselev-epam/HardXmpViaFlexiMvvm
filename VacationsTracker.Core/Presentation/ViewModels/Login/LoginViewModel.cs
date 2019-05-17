using FlexiMvvm.Commands;
using FlexiMvvm.Operations;
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
        private readonly IOperationFactory _operationFactory;
        private string _login;
        private string _loginError;
        private string _password;
        private string _passwordError;
        private string _errorMessage;
        private bool _errorMessageVisible;
        private bool _signInVisible;

        public LoginViewModel(
            INavigationService navigationService,
            IXmpProxy xmpProxy,
            IOperationFactory operationFactory)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _xmpProxy = xmpProxy ?? throw new ArgumentNullException(nameof(xmpProxy));
            _operationFactory = operationFactory ?? throw new ArgumentNullException(nameof(operationFactory));
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

        private Task SignIn()
        {
            if (string.IsNullOrWhiteSpace(Login)
                || string.IsNullOrWhiteSpace(Password))
            {
                // TODO: include fluent validation
                ErrorMessage = Strings.Invalid_Error_Message;
                return Task.CompletedTask;
            }

            SignInVisible = false;

            return _operationFactory.Create(this)
                .WithExpressionAsync(_ => _xmpProxy.AuthenticateAsync(Login, Password))
                .OnSuccess(_ => _navigationService.NavigateToMainList(this))
                .OnError<AuthenticationException>(_ =>
                {
                    ErrorMessage = Strings.Auth_Error_Message;
                    SignInVisible = true;
                })
                .OnError<CommunicationException>(_ =>
                {
                    ErrorMessage = Strings.Communication_Error_Message;
                    SignInVisible = true;
                })
                .OnError<Exception>(_ =>
                {
                    ErrorMessage = Strings.Unexpected_Error_Message;
                    SignInVisible = true;
                })
                .ExecuteAsync();
        }

        public override void Initialize()
        {
            base.Initialize();

            //TODO login view initialization
            // ....

            // temporary
            //ErrorMessage = "Please, retry your login and password pair. Check current Caps Lock and input language settings";
        }
    }
}
