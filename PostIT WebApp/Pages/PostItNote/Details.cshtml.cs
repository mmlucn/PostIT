using MauiLib.DTOs;
using Microsoft.AspNetCore.Authorization;
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
            bool isAuthorized = _httpClient.DefaultRequestHeaders.Contains("Authorization");
            if (isAuthorized == false)
            {
                TempData["Message"] = "You cannot access this page without being logged in, please log in or create an account if you havent already";
                return RedirectToPage("/Account/LoginPage2");
            }

            var res = await _httpClient.GetFromJsonAsync<PostItNoteDTO>($"api/Note/{id}");
            if (res.Id > 0)
            {
                Note = res;

            }



            return null;
        }
    }
}
