using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.FirebasePushNotification;
using System;

namespace Imi.Project.Mobile.Droid
{
    [Application]
    public class MainApplication: Application
    {
        public MainApplication(IntPtr handler, JniHandleOwnership transfer) : base(handler, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            if(Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId =
                    "FirebasePushNotificationChannel";

                FirebasePushNotificationManager.DefaultNotificationChannelName =
                    "General";
            }

#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {

            };
        }
    }
}