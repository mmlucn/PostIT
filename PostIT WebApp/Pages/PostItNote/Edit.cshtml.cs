using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MauiLib.Models;
using MauiLib.DTOs;

namespace PostIT_WebApp.Pages.PostItNote
{
    public class EditModel : PageModel
    {
        

        public EditModel()
        {
            
        }

        [BindProperty]
        public PostItNoteDTO PostItNote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var postitnote =  await _context.PostItNote.FirstOrDefaultAsync(m => m.Id == id);
            //if (postitnote == null)
            //{
            //    return NotFound();
            //}
            //PostItNote = postitnote;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(PostItNote).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostItNoteExists(PostItNote.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostItNoteExists(int id)
        {
            return true;//(_context.PostItNote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
