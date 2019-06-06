using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using System;
using UIKit;
using VacationsTracker.iOS.Infrastructure.Extensions;

namespace VacationsTracker.iOS.Infrastructure.Bindings
{
    public static class UIImageViewBindings
    {
        public static TargetItemBinding<UIImageView, string> BundleImageBinding(
            this IItemReference<UIImageView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, string>(
                viewReference,
                (view, imageSetId) => view.NotNull().SetBundleImage(imageSetId),
                () => $"{nameof(ImageViewExtensions.SetBundleImage)}");
        }
    }
}