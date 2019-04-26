using FlexiMvvm.Operations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VacationsTracker.Core.Infrastructure
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly IDialogService _dialogService;

        public ErrorHandler(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public Task HandleAsync(OperationContext context, OperationError<Exception> error, CancellationToken cancellationToken)
        {
            // TODO: implement specific exceptions
            // ...
            // _dialogService.ShowAlert(string.Empty, "Oops..");

            return Task.CompletedTask;
        }
    }
}
