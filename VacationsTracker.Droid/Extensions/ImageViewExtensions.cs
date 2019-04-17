using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using System;

namespace VacationsTracker.Droid.Extensions
{
    public static class ImageViewExtensions
    {
        public static TargetItemBinding<ImageView, int> DrawableBinding(
            this IItemReference<ImageView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                viewReference,
                (view, drawable) => view.NotNull().SetImageResource(drawable),
                () => $"{nameof(ImageView.SetImageResource)}");
        }
    }
}