using System;
using UIKit;

namespace VacationsTracker.iOS.Theme
{
    public class AppThemeColors
    {
        public UIColor Primary { get; } = FromHex("#2c3e50");
        public UIColor PrimaryDark { get; } = FromHex("#4B4A67");
        public UIColor Accent { get; } = FromHex("#3498db");
        public UIColor White { get; } = FromHex("#ffffff");
        public UIColor Bright { get; } = FromHex("#39c5d6");
        public UIColor DarkRed { get; } = FromHex("#a55171");
        public UIColor MsgBkgnd { get; } = FromHex("#f8f8f8");
        public UIColor GrayText { get; } = FromHex("#bfbec1");
        public UIColor DateGreen { get; } = FromHex("#98c838");
        public UIColor TextHint { get; } = FromHex("#0C0910", 0.4f);

        public static UIColor FromHex(string value, float alpha = 1.0f)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                value = string.Empty;
            }
            value = value.Trim();

            alpha = (alpha < 0.0f) ? 0.0f : (alpha > 1.0f) ? 1.0f : alpha;

            var hexValue = value.Replace("#", string.Empty);
            float red, green, blue;

            switch (hexValue.Length)
            {
                case 3: // #RGB
                    red = Convert.ToInt32(string.Format("{0}{0}", hexValue.Substring(0, 1)), 16) / 255f;
                    green = Convert.ToInt32(string.Format("{0}{0}", hexValue.Substring(1, 1)), 16) / 255f;
                    blue = Convert.ToInt32(string.Format("{0}{0}", hexValue.Substring(2, 1)), 16) / 255f;
                    return UIColor.FromRGBA(red, green, blue, alpha);
                case 6: // #RRGGBB
                    red = Convert.ToInt32(hexValue.Substring(0, 2), 16) / 255f;
                    green = Convert.ToInt32(hexValue.Substring(2, 2), 16) / 255f;
                    blue = Convert.ToInt32(hexValue.Substring(4, 2), 16) / 255f;
                    return UIColor.FromRGBA(red, green, blue, alpha);
                default:
                    return UIColor.Clear;
            }
        }
    }
}