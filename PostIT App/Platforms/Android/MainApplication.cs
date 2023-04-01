using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using AndroidX.Core.Content;

namespace PostIT_App
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}