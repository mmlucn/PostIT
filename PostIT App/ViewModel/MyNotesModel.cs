using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
using PostIT_App.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_App.ViewModel
{
    public partial class MyNotesModel : ObservableObject
    {
        HttpClient _httpClient;

        [ObservableProperty]
        List<PostItNoteDTO> notes = new List<PostItNoteDTO>();

        [ObservableProperty]
        bool isRefreshingNotes = false;

        public MyNotesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnNavigatedTo()
        {
            IsRefreshingNotes = true;
            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            if (res.Count == 0)
            {
                App.Current.MainPage = PostIT_App.Helpers.ServiceProvider.GetService<AddNotePage>();

            }
            Notes = res;
            IsRefreshingNotes = false;
        }

        [RelayCommand]
        public async Task RefreshNotes()
        {
            IsRefreshingNotes = true;
            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            Notes = res;
            IsRefreshingNotes = false;
        }

        [RelayCommand]
        private async void Delete(PostItNoteDTO note)
        {
            await AppShell.Current.DisplayAlert("Hi", "HIHI", "OK");
        }
    }
}
