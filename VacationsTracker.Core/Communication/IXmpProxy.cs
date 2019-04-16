using System;
using System.Threading.Tasks;

namespace VacationsTracker.Core.Communication
{
    public partial interface IXmpProxy : IDisposable
    {
        Task Authenticate(string login, string passw);
    }
}
