using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MauiLib.Models;
using MauiLib.DTOs;

namespace PostIT_WebApp.Pages.PostItNote
{
    public class DeleteModel : PageModel
    {
        

        public DeleteModel()
        {
            
        }

        [BindProperty]
      public PostItNoteDTO PostItNote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {



            return null;
            
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            
            

            
            return RedirectToPage("./Index");
        }
    }
}
