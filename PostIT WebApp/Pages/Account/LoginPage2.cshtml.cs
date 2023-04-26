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
        public LoginModel _loginModel;
        public LoginPage2Model(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _loginModel = new LoginModel(_httpClient);
            
           
        }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            _loginModel = new LoginModel(_httpClient);
        }
        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                _loginModel.UsernameEntry = UserName;
                _loginModel.PasswordEntry = Password;

                await _loginModel.LoginCommand.ExecuteAsync(null);
                if (_loginModel.LoginCommand.ExecutionTask.IsCompletedSuccessfully)
                {
                    return RedirectToPage("/PostItNote/MyNotesPage");
                }
                

            }
            return Page();
        }
        
    }
}
