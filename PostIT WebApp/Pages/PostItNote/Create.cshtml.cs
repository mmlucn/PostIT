using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MauiLib.Models;
using MauiLib.DTOs;

namespace PostIT_WebApp.Pages.PostItNote
{
    public class CreateModel : PageModel
    {
        HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PostItNoteDTO PostItNote { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var res = await _httpClient.PostAsJsonAsync<PostItNoteDTO>("api/Note?postItNote=", PostItNote);


            }

            

            return RedirectToPage("./Index");
        }
    }
}
