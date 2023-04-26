﻿
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_WebApp.ViewModel
{
    public partial class LoginModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
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
                
                    var res = await _httpClient.PostAsJsonAsync("api/Token", new LoginDTO(UsernameEntry, PasswordEntry));
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var token = await res.Content.ReadAsStringAsync();
                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    
                }
            }
        }

        //[RelayCommand]
        //private async Task Reg()
        //{
            
        //}
    }
}
