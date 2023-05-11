﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        PostItNoteDTO postItNoteDTO;

        [ObservableProperty]
        bool isRefreshingNotes = false;
		[ObservableProperty]
		string searchTerm;


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
            Search();
            IsRefreshingNotes = false;
        }

        [RelayCommand]
        public async Task RefreshNotes()
        {
            IsRefreshingNotes = true;
            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            Notes = res;
            Search();
            IsRefreshingNotes = false;
        }

        [RelayCommand]
        private async void Delete(PostItNoteDTO note)
        {
            await AppShell.Current.DisplayAlert("Hi", "HIHI", "OK");
        }

        [RelayCommand]
        private async Task Details(int id)
        {
            await AppShell.Current.GoToAsync($"detailspage?id={id}");
        }

		[RelayCommand]
		private async void RefreshAllNotes()
		{
			IsRefreshingNotes = true;
			var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
			Notes = res;
			SearchTerm = "";
			IsRefreshingNotes = false;
		}

		[RelayCommand]
		private void Search()
		{
			if (!string.IsNullOrEmpty(SearchTerm))
			{
				Notes = notes.Where(note => note.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                SearchTerm = "";

			}
			else
			{
				Notes = notes;
			}
		}

	}
}
