using System;
using FlexiMvvm.Exceptions;

namespace VacationsTracker.Core.Infrastructure.Connectivity
{
    public class ConnectivityException : Exception, IUserFriendlyException
    {
        public ConnectivityException(string message)
            : base(message)
        {
        }
    }
}
