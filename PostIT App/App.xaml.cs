using PostIT_App.Helpers;
using ServiceProvider = PostIT_App.Helpers.ServiceProvider;

namespace PostIT_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = ServiceProvider.GetService<LoginPage>();
        }
    }
}