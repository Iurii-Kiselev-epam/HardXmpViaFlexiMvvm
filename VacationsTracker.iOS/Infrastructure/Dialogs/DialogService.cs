using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using VacationsTracker.Core.Infrastructure;

namespace VacationsTracker.iOS.Infrastructure.Dialogs
{
    public class DialogService : IDialogService
    {
        public void ShowAlert(string title, string message)
        {
            // TODO: implement alert in Android
            // ...
        }

        public Task<bool> ShowMessageBox(string title, string message)
        {
            // TODO: implement message box in Android
            // ...
            return Task.FromResult<bool>(true);
        }
    }
}