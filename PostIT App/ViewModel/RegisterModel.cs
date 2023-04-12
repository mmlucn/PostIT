using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_App.ViewModel
{
    public partial class RegisterModel : ObservableObject
    {
        private HttpClient _httpClient;
        

        public RegisterModel(HttpClient httpClient)
        {
            _httpClient= httpClient;
            

        }

        [ObservableProperty]
        string firstNameEntry = "h";
        [ObservableProperty]
        string lastNameEntry = "";
        [ObservableProperty]
        string emailEntry = "";
        [ObservableProperty]
        string userNameEntry = "";
        [ObservableProperty]
        string passwordEntry = "";
        [ObservableProperty]
        string confirmPasswordEntry = "";

        [RelayCommand]
        private async Task Register()
        {
            if (!string.IsNullOrEmpty(FirstNameEntry) && !string.IsNullOrWhiteSpace(LastNameEntry) &&
                !string.IsNullOrWhiteSpace(EmailEntry) && !string.IsNullOrWhiteSpace(UserNameEntry) &&
                    !string.IsNullOrWhiteSpace(PasswordEntry) && PasswordEntry == ConfirmPasswordEntry)
            {
                try
                {
                    var res = await _httpClient.PostAsJsonAsync("api/Token/Register", new UserDTO(FirstNameEntry, LastNameEntry, EmailEntry, UserNameEntry, PasswordEntry));
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        
                    }
                }
                catch (Exception ex)
                {
                    await AppShell.Current.DisplayAlert("Error", ex.Message, "Ok");
                    throw;
                }


            }
        }

    }
}
