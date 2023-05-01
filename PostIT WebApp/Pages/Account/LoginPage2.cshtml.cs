using MauiLib.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostIT_WebApp.ViewModel;
using System.ComponentModel;

namespace PostIT_WebApp.Pages.Account
{
    public class LoginPage2Model : PageModel
    {
        private readonly HttpClient _httpClient;
        //public LoginModel _loginModel;
        public LoginPage2Model(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_loginModel = new LoginModel(_httpClient);
            
           
        }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        


        public void OnGet()
        {
           
            


        }
        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                var res = await _httpClient.PostAsJsonAsync("api/Token", new LoginDTO(UserName, Password));
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var token = await res.Content.ReadAsStringAsync();
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    return RedirectToPage("/PostItNote/MyNotesPage");

                }

                

            }
            return Page();


        }
        
    }
}
