using System;
namespace VacationsTracker.Core.Communication
{
    public class AuthenticationException : ApplicationException
    {
        public AuthenticationException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
