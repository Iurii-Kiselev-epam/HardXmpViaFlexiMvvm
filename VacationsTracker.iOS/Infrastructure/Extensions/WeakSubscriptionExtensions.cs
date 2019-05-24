using FlexiMvvm.Collections;
using FlexiMvvm.Weak.Subscriptions;
using System;
using UIKit;

namespace VacationsTracker.iOS.Infrastructure.Extensions
{
    /// <summary>
    /// Copied from BFLA.
    /// </summary>
    public static class WeakSubscriptionExtensions
    {
        public static IDisposable StartedWeakSubscribe(
            this UITextField eventSource,
            EventHandler eventHandler)
        {
            return new EventHandlerWeakEventSubscription<UITextField>(eventSource,
                (control, handler) => control.Started += handler,
                (control, handler) => control.Started -= handler,
                eventHandler);
        }

        public static IDisposable CurrentItemIndexChangedWeakSubscribe(
            this PageViewControllerObservableDataSource eventSource,
            EventHandler<IndexChangedEventArgs> eventHandler)
        {
            return new EventHandlerWeakEventSubscription<PageViewControllerObservableDataSource, IndexChangedEventArgs>(eventSource,
                (control, handler) => control.CurrentItemIndexChanged += handler,
                (control, handler) => control.CurrentItemIndexChanged -= handler,
                eventHandler);
        }
    }
}