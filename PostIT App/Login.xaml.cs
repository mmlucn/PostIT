using Microsoft.Extensions.DependencyInjection;
using PostIT_App.Helpers;
using PostIT_Lib;
using PostIT_Lib.Models;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using ServiceProvider = PostIT_App.Helpers.ServiceProvider;

namespace PostIT_App
{
    public partial class MainPage : ContentPage
    {
        HttpClient _httpClient { get; set; }
        public MainPage()
        {
            InitializeComponent();
            _httpClient = ServiceProvider.Current.GetRequiredService<HttpClient>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (UsernameEntry != null && PasswordEntry != null)
            {
                var res = await _httpClient.PostAsJsonAsync("api/Token", new {Username = UsernameEntry.Text, Password = PasswordEntry.Text});
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var token = await res.Content.ReadAsStringAsync();
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    App.Current.MainPage = new PostItNotePage();
                }
            }
        }

    }
}