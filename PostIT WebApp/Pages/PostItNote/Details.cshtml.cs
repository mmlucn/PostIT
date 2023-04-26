using MauiLib.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PostIT_WebApp.Pages.PostItNote
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public PostItNoteDTO Note { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var res = _httpClient.GetFromJsonAsync<PostItNoteDTO>($"api/Note/{id}");
            if (res.IsCompletedSuccessfully)
            {
                Note = res.Result;

            }



            return null;
        }
    }
}
