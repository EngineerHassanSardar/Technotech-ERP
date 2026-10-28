using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;

namespace TechnotechInnovation.ERPMobile
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // THIS FORCES ANDROID TO PUSH THE APP DOWN BELOW THE CLOCK
            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
                WindowCompat.SetDecorFitsSystemWindows(Window, true);
            }
        }
    }
}