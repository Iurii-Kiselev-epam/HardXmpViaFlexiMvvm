using UIKit;

namespace VacationsTracker.iOS.Theme
{
    public class AppThemeFonts
    {
        const string PreferredFont = "Verdana";

        public UIFont Title { get; } = UIFont.FromName(PreferredFont, 23);
        public UIFont Input1 { get; } = UIFont.FromName(PreferredFont, 16);
        public UIFont Cell { get; } = UIFont.FromName(PreferredFont, 11);
        public UIFont CellLarge { get; } = UIFont.FromName(PreferredFont, 13);
        public UIFont Message { get; } = UIFont.FromName(PreferredFont, 11);
        public UIFont Day { get; } = UIFont.FromName(PreferredFont, 36);
        public UIFont Month { get; } = UIFont.FromName(PreferredFont, 18);
        public UIFont Year { get; } = UIFont.FromName(PreferredFont, 12);
    }
}