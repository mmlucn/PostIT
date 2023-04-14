using PostIT_App.Helpers;
using PostIT_App.Pages;
using ServiceProvider = PostIT_App.Helpers.ServiceProvider;

namespace PostIT_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute("mynotes", typeof(MyNotesPage));
            Routing.RegisterRoute("addnote", typeof(AddNotePage));
            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("settings", typeof(SettingsPage));
            MainPage = new AppShell();
        }
    }
}