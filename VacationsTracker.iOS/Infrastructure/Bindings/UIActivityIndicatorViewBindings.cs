using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using System;
using UIKit;

namespace VacationsTracker.iOS.Infrastructure.Bindings
{
    public static class UIActivityIndicatorViewBindings
    {
        public static TargetItemBinding<UIActivityIndicatorView, bool> ActivityBinding(
            this IItemReference<UIActivityIndicatorView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIActivityIndicatorView, bool>(
                viewReference,
                (view, hidden) =>
                {
                    if (hidden)
                    {
                        if (view.IsAnimating)
                            view.StopAnimating();
                    }
                    else if(!view.IsAnimating)
                    {
                        view.StartAnimating();
                    }
                    view.Hidden = hidden;
                },
                () => "Hidden");
        }
    }
}