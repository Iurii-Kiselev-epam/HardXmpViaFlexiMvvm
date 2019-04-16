using Android.Content;

namespace VacationsTracker.Droid.Extensions
{
    public static class IntentExtensions
    {
        public static void CleanBackStack(this Intent intent)
        {
            intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
        }
    }
}