using PostIT_App.Pages;
using PostIT_App.ViewModel;

namespace PostIT_App.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginModel loginModel)
    {
        InitializeComponent();
        BindingContext = loginModel;
    }
}