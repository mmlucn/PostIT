using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MauiLib.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PostIT_WebApp.Pages
{
    
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient1 )
        {
            
            _httpClient = httpClient1;
        }

        [BindProperty]
        public PostItNoteDTO Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            bool isAuthorized = _httpClient.DefaultRequestHeaders.Contains("Authorization");
            if (isAuthorized == false)
            {
                
                return RedirectToPage("/Account/LoginPage2");
            }

            if (id == null)
            {
                return NotFound();
            }

            var res = await _httpClient.GetFromJsonAsync<PostItNoteDTO>($"api/Note/{id}");
            if (res !=null)
            {
                Note = res;
            }

            if (Note == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                await _httpClient.DeleteFromJsonAsync<PostItNoteDTO>($"api/Note/{id}");
            }
            
            return RedirectToPage("./MyNotesPage");
        }
    }
}
