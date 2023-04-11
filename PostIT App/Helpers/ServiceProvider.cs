using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_App.Helpers
{
    public static class ServiceProvider
    {
        public static TService GetService<TService>()
            => Current.GetService<TService>();

        public static IServiceProvider Current =>
#if WINDOWS
        MauiWinUIApplication.Current.Services;
#elif ANDROID
        MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#endif
    }
}
