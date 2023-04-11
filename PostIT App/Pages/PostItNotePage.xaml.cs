namespace PostIT_App;

using Microsoft.Maui.Controls;
using PostIT_Lib.Models;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Helpers;
using System.IdentityModel.Tokens.Jwt;

public partial class PostItNotePage : ContentPage
{   HttpClient _httpClient;
    string userId = string.Empty;

    public PostItNotePage()
    {
        InitializeComponent();
        BindingContext = this;
        _httpClient = ServiceProvider.GetService<HttpClient>();
        var handler = new JwtSecurityTokenHandler();
        var res = handler.ReadJwtToken(_httpClient.DefaultRequestHeaders.Authorization.ToString().Split(' ')[1]);
        userId = res.Claims.First(c => c.Type == "UserID").Value;
    }

    private async void saveNote_Clicked(object sender, EventArgs e)
    {
        try
        {
            var res = await _httpClient.PostAsJsonAsync<PostItNote>($"api/PostIT2?postItNote=", new PostItNote()
            {
                Category = CategoryEntry.Text,
                Text = NoteText.Text,
                Title = TitleEntry.Text,
                Created = DateTime.UtcNow,
                Id = 0,
                Image = null
            });

            if (res.IsSuccessStatusCode)
            {
                await Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Ok");
            throw;
        }
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var action = await DisplayActionSheet("Select Photo", "Cancel", null, "Take Photo", "Choose Photo");

        if (action == "Take Photo")
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            var stream = new MemoryStream();
            photo.OpenReadAsync().Result.CopyTo(stream);
            // Do something with the photo
            var res = _httpClient.PostAsJsonAsync($"api/OCR/Post?bytes=", stream.ToArray());
            var text = await res.Result.Content.ReadAsStringAsync();


            NoteText.Text = text;
        }
        else if (action == "Choose Photo")
        {
            var photo = await MediaPicker.PickPhotoAsync();
            var stream = new MemoryStream();
            photo.OpenReadAsync().Result.CopyTo(stream);
            // Do something with the photo
            var res = _httpClient.PostAsJsonAsync($"api/OCR/Post?bytes=", stream.ToArray());
            var text = await res.Result.Content.ReadAsStringAsync();

           
            NoteText.Text = text;
            
        }
    }
}