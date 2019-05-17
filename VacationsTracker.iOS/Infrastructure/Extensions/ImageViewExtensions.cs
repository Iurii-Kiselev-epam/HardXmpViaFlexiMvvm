using UIKit;

namespace VacationsTracker.iOS.Infrastructure.Extensions
{
    public static class ImageViewExtensions
    {
        public static UIImageView SetBundleImage(this UIImageView imageView, string imageName)
        {
            using (var imageFromBundle = UIImage.FromBundle(imageName))
            {
                imageView.Image = imageFromBundle;
            }
            return imageView;
        }
    }
}