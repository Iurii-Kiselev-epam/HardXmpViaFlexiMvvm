namespace VacationsTracker.iOS.Theme
{
    public sealed class AppTheme
    {
        public static AppTheme Current { get; } = new AppTheme();

        public AppThemeColors Colors { get; } = new AppThemeColors();

        public AppThemeDimens Dimens { get; } = new AppThemeDimens();

        public AppThemeFonts Fonts { get; } = new AppThemeFonts();
    }
}