using PostIT_App.ViewModel;

namespace PostIT_App.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsModel settingsModel)
	{
		InitializeComponent();
		BindingContext = settingsModel;
	}
}