namespace VacationsTracker.Core.Domain
{
    public static class UserConstants
    {
        public static class Default
        {
            public const string Login = "ark";
            public const string Password = "123";
        }

        public static class Errors
        {
            public const string AuthErrorMessage = "Login and password pair looks not correct. Please, retry them. Check current Caps Lock and input language settings";
            public const string CommunicationErrorMessage = "Communication error. Please retry later";
            public const string UnexpectedErrorMessage = "Unexpected error during authentification. Please retry later";
            public const string InvalidErrorMessage = "Login and password pair is invalid";
        }
    }
}
