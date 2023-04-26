using MauiLib.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostIT_WebApp.ViewModel;

namespace PostIT_WebApp.Pages.PostItNote
{
    public class MyNotesPageModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private MyNotesModel _myNotesModel;


        public MyNotesPageModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _myNotesModel = new MyNotesModel(httpClient);
        }

       
        public List<PostItNoteDTO> Notes { get; set; }


        public async void OnGet()
        {

            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            
                Notes = res.ToList();


            

            //await _myNotesModel.RefreshNotesCommand.ExecuteAsync(_httpClient);
            //if (_myNotesModel.RefreshNotesCommand.ExecutionTask.IsCompletedSuccessfully)
            //{
            //    Notes = _myNotesModel.Notes.ToList();

            //}



        }
    }
}
