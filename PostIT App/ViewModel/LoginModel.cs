using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
using PostIT_App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_App.ViewModel
{
    public partial class LoginModel : ObservableObject
    {
        private HttpClient _httpClient;
        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ObservableProperty]
        string usernameEntry = "malthe";

        [ObservableProperty]
        string passwordEntry = "Malthe!";

        [RelayCommand]
        private async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(UsernameEntry) && !string.IsNullOrWhiteSpace(PasswordEntry))
            {
                try
                {
                    var res = await _httpClient.PostAsJsonAsync("api/Token", new LoginDTO(UsernameEntry, PasswordEntry));
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var token = await res.Content.ReadAsStringAsync();
                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await Toast.Make("Something went wrong").Show();
                    }
                }
                catch (Exception ex)
                {
                    
                    await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                }
            }
        }

        [RelayCommand]
        private async Task Reg()
        {
            //App.Current.MainPage = PostIT_App.Helpers.ServiceProvider.GetService<RegisterPage>();
            await Shell.Current.GoToAsync("register");
        }
    }
}
