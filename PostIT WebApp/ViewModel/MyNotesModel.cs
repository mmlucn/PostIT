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

namespace PostIT_WebApp.ViewModel
{
    public partial class MyNotesModel : ObservableObject
    {
        HttpClient _httpClient;

        [ObservableProperty]
        List<PostItNoteDTO> notes = new List<PostItNoteDTO>();

        [ObservableProperty]
        PostItNoteDTO postItNoteDTO;

        [ObservableProperty]
        bool isRefreshingNotes = false;

        public MyNotesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task OnNavigatedTo()
        {

            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            if (res.Count == 0)
            {


            }
            Notes = res;

        }

        [RelayCommand]
        public async Task RefreshNotes()
        {

            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            Notes = res;


        }




    }
}
