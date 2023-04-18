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
    public class DetailsModel : PageModel
    {
       

        public DetailsModel()
        {
           
        }

      public PostItNoteDTO PostItNote { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            //var postitnote = await _context.PostItNote.FirstOrDefaultAsync(m => m.Id == id);
            //if (postitnote == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    PostItNote = postitnote;
            //}
            return Page();
        }
    }
}
