using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PostIT_App.ViewModel
{
    public partial class SettingsModel : ObservableObject
    {
        [RelayCommand]
        private async void NavTest()
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
