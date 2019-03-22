using System;
using FlexiMvvm.Weak.Subscriptions;
using Xamarin.Essentials;

namespace VacationsTracker.Core.Infrastructure.Connectivity
{
    public static class ConnectivityWeakEventSubscription
    {
        public static IDisposable ConnectivityChangedWeakSubscribe(
            this IConnectivity connectivity,
            EventHandler<ConnectivityChangedEventArgs> connectivityChangedHandler)
        {
            return new EventHandlerWeakEventSubscription<IConnectivity, ConnectivityChangedEventArgs>(
                connectivity,
                (eventSource, eventHandler) => eventSource.ConnectivityChanged += eventHandler,
                (eventSource, eventHandler) => eventSource.ConnectivityChanged -= eventHandler,
                connectivityChangedHandler);
        }
    }
}
