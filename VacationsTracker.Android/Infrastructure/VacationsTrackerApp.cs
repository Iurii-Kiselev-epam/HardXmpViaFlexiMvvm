using Android.App;
using Android.Runtime;
using System;
using VacationsTracker.Android.Bootstrappers;
using VacationsTracker.Core.Bootstrappers;

namespace VacationsTracker.Android.Infrastructure
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    public class VacationsTrackerApp : Application
    {
        public VacationsTrackerApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            BootstrapRunner.Run(() => new AndroidBootstrapper());
        }
    }
}
