namespace PostIT_App;

using Microsoft.Maui.Controls;
using PostIT_Lib.Models;
using System.Net.Http.Json;

public partial class PostItNotePage : ContentPage
{
    public PostItNote PostItNote { get; set; } = new PostItNote()
    {
        Category = "",
        Created = DateTime.Now,
        Id = 0,
        Text = "Hello",
        Title = "",
        Image = null
    };
    HttpClient _httpClient;

    public PostItNotePage(HttpClient httpClient)
    {
        InitializeComponent();
        BindingContext = this;
        _httpClient = httpClient;
    }

    private async void saveNote_Clicked(object sender, EventArgs e)
    {

        var res = await _httpClient.PostAsJsonAsync<PostItNote>($"https://localhost:7081/api/PostIT2?postItNote=", PostItNote);

        if (res.IsSuccessStatusCode)
        {
            await Navigation.PopAsync();

        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var action = await DisplayActionSheet("Select Photo", "Cancel", null, "Take Photo", "Choose Photo");

        if (action == "Take Photo")
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            // Do something with the photo
        }
        else if (action == "Choose Photo")
        {
            var photo = await MediaPicker.PickPhotoAsync();
            var stream = new MemoryStream();
            photo.OpenReadAsync().Result.CopyTo(stream);
            // Do something with the photo
            var res = _httpClient.PostAsJsonAsync($"https://localhost:7081/api/OCR/Post?bytes=", stream.ToArray());
            var text = await res.Result.Content.ReadAsStringAsync();

           
            NoteText.Text = text;
            
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var action = await DisplayActionSheet("Select Photo", "Cancel", null, "Take Photo", "Choose Photo");
         
        if (action == "Take Photo")
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            
            // Do something with the photo
            var res = _httpClient.PostAsJsonAsync($"https://localhost:7081/api/OCR/Post?bytes=", PostItNote);

        }
        else if (action == "Choose Photo")
        {
            var photo = await MediaPicker.PickPhotoAsync();
            var stream = new MemoryStream();
            photo.OpenReadAsync().Result.CopyTo(stream);
            // Do something with the photo
            var res = _httpClient.PostAsJsonAsync($"https://localhost:7081/api/OCR/Post?bytes=", stream.ToArray());
            var text = await res.Result.Content.ReadAsStringAsync();
            
            PostItNote.Text.Replace(PostItNote.Text , text);
        }
        
    }
}