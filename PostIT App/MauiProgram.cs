using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using PostIT_App.Pages;
using PostIT_App.ViewModel;
using CommunityToolkit.Maui;

namespace PostIT_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7081/");
            builder.Services.AddSingleton<HttpClient>(httpClient);


            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginModel>();

            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterModel>();

            builder.Services.AddSingleton<MyNotesPage>();
            builder.Services.AddSingleton<MyNotesModel>();

            builder.Services.AddSingleton<AddNotePage>();
            builder.Services.AddSingleton<AddNoteModel>();

            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<SettingsModel>();
            return builder.Build();
        }
    }
}