using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
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
        public MyNotesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Notes = new List<PostItNoteDTO>();
        }

        public async Task OnNavigatedTo()
        {
            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            Notes = res;
        }

        [ObservableProperty]
        List<PostItNoteDTO> notes;

        [RelayCommand]
        private void Delete(PostItNoteDTO note)
        {
            AppShell.Current.DisplayAlert("Hi", "HIHI", "OK");
        }
    }
}
