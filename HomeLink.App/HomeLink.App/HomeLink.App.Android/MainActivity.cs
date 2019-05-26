using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace HomeLink.App.Droid
{
    [Activity(Label = "HomeLink", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Window.Attributes.LayoutInDisplayCutoutMode = Android.Views.LayoutInDisplayCutoutMode.ShortEdges;

            base.OnCreate(bundle);

            //Xamarin.Forms.Forms.SetTitleBarVisibility(this, Xamarin.Forms.AndroidTitleBarVisibility.Never);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

