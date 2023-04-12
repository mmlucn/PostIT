using PostIT_App.Pages;
using PostIT_App.ViewModel;

namespace PostIT_App
{
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage(LoginModel loginModel)
        {
            InitializeComponent();
            BindingContext = loginModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
            
        }
    }
}