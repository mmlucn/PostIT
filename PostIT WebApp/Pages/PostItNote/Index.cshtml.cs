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
    public class IndexModel : PageModel
    {
        private HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IList<PostItNoteDTO> PostItNote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var res = await _httpClient.GetFromJsonAsync<List<PostItNoteDTO>>("api/Note");
            if (res != null)
            {
                PostItNote = res;
                
            }
        }
    }
}
