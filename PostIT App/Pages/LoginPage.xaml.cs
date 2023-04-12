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
    }
}