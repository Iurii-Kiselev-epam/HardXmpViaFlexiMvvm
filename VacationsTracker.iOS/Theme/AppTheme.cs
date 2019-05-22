using UIKit;

namespace VacationsTracker.iOS.Theme
{
    public sealed class AppTheme
    {
        public static AppTheme Current { get; } = new AppTheme();

        public AppThemeColors Colors { get; }

        public AppThemeDimens Dimens { get; }

        public AppThemeFonts Fonts { get; }

        private AppTheme()
        {
            Colors = new AppThemeColors();
            Dimens = new AppThemeDimens();
            Fonts = new AppThemeFonts();

            SetNavigationBarAppearance();
        }

        private void SetNavigationBarAppearance()
        {
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = Colors.Bright;
            UINavigationBar.Appearance.Translucent = false;
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.White,
                Font = Fonts.Title
            };
        }

    }
}
