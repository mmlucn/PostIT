using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostIT_App.ViewModel;
using System.ComponentModel;

namespace PostIT_WebApp.Pages.Account
{
    public class RegisterPageModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public RegisterModel _registerModel;


        public RegisterPageModel(HttpClient httpClient1)
        {
            _httpClient = httpClient1;
            _registerModel = new RegisterModel(_httpClient);

        }

        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        [BindProperty]
        public string UserName { get; set; }

        public void OnGet()
        {
            _registerModel = new RegisterModel(_httpClient);

        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                _registerModel.FirstNameEntry = FirstName;
                _registerModel.LastNameEntry= LastName;
                _registerModel.EmailEntry = Email;
                _registerModel.PasswordEntry = Password;
                _registerModel.ConfirmPasswordEntry = ConfirmPassword;
                _registerModel.UserNameEntry = UserName;

                await _registerModel.RegisterCommand.ExecuteAsync(null);
                if (_registerModel.RegisterCommand.ExecutionTask.IsCompletedSuccessfully)
                {
                    return RedirectToPage("/Account/LoginPage2");
                }
                

            }
            return Page();
        }
    }
}
