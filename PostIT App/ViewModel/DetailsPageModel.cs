using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PostIT_App.ViewModel
{
    public partial class DetailsPageModel : ObservableObject, IQueryAttributable
    {
        public HttpClient _httpClient { get; set; }
        public DetailsPageModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ObservableProperty]
        int? id;

        [ObservableProperty]
        PostItNoteDTO postItNote;

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var temp = query["id"] as string;
            Id = int.Parse(temp);
            PostItNote = await _httpClient.GetFromJsonAsync<PostItNoteDTO>($"api/Note/{Id}");
        }
        [RelayCommand]
        private async Task DeleteNote()
        {
            var res = await _httpClient.DeleteAsync($"api/Note/{PostItNote.Id}");
            if (res.IsSuccessStatusCode)
            {
                await Shell.Current.Navigation.PopToRootAsync();

            }

        }

    }
    


}
