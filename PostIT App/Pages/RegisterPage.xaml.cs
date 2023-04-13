using PostIT_App.ViewModel;

namespace PostIT_App.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterModel registermodel)
	{
		InitializeComponent();
        BindingContext= registermodel;
    }
	
}