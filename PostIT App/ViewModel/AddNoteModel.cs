using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
using System.Data;
using System.Net.Http.Json;
using System.Threading;

namespace PostIT_App.ViewModel
{
    public partial class AddNoteModel : ObservableObject 
    {
        HttpClient _httpClient;
        ImageDTO _imageDTO = null;
        public AddNoteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ObservableProperty]
        string noteTitle = string.Empty;

        [ObservableProperty]
        string noteCategory = string.Empty;

        [ObservableProperty]
        string noteText = string.Empty;

        [RelayCommand]
        private async Task GetPhoto()
        {
            var action = await AppShell.Current.DisplayActionSheet("Select Photo", "Cancel", null, "Take Photo", "Choose Photo");

            if (action == "Take Photo")
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions() { Title = "Take photo"});

                var stream = new MemoryStream();
                photo.OpenReadAsync().Result.CopyTo(stream);

                // Do something with the photo
                var res = _httpClient.PostAsJsonAsync($"api/OCR/Post?bytes=", stream.ToArray());
                var text = await res.Result.Content.ReadAsStringAsync();


                NoteText = text;
            }
            else if (action == "Choose Photo")
            {
                var photo = await MediaPicker.PickPhotoAsync();
                var stream = new MemoryStream();
                photo.OpenReadAsync().Result.CopyTo(stream);
                // Do something with the photo
                var res = _httpClient.PostAsJsonAsync($"api/OCR/Post?bytes=", stream.ToArray());
                var text = await res.Result.Content.ReadAsStringAsync();


                NoteText = text;

            }
        }

        [RelayCommand]
        private async Task SaveNote()
        {
            
            PostItNoteDTO postItNoteDTO = new PostItNoteDTO()
            {   
                
                Category = NoteCategory,
                Title = NoteTitle,
                Text = NoteText,
                Image = _imageDTO
            };

            var res = await _httpClient.PostAsJsonAsync<PostItNoteDTO>("api/Note", postItNoteDTO);
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                await AppShell.Current.DisplayAlert("Error", res.StatusCode.ToString(), "OK");


            NoteCategory = string.Empty;
            NoteTitle = string.Empty;
            NoteText = string.Empty;
            _imageDTO = null;
        }
        
    }
}
