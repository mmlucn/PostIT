using PostIT_App.ViewModel;

namespace PostIT_App.Pages;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsPageModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}