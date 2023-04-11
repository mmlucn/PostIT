using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;

namespace PostIT_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://cz6tk78q-7081.euw.devtunnels.ms/");
            builder.Services.AddSingleton<HttpClient>(httpClient);
            

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}