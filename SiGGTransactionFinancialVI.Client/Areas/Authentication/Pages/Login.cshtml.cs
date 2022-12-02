using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Interfaces;
using SiGGTransactionFinancialVI.Client.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancialVI.Client.Areas.Authentication.Pages
{
    public class Login : PageModel
    {

        private readonly IBodyGuardAuthenticationApiService _authenticationApiService;

        public Login(IBodyGuardAuthenticationApiService authenticationApiService)
        {
            _authenticationApiService = authenticationApiService;
        }

        [BindProperty]
        public AuthenticationForm AuthenticationForm { get; set; }

        public void OnGet(string returnUrl)
        {
            AuthenticationForm = new AuthenticationForm();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Login failed.";
                return RedirectToPage(AuthenticationForm.LoginFailurePage,
                                      new {Area = AuthenticationForm.LoginFailureArea});
            }

            var response = await _authenticationApiService.Login
                               (AuthenticationForm.LoginRequest.EmailAddress, AuthenticationForm.LoginRequest.Password);

            if (response.Success)
            {
                TempData["Message"] = "Login succeed!";
                return RedirectToPage(AuthenticationForm.LoginSuccessPage,
                                      new {Area = AuthenticationForm.LoginSuccessArea});
            }

            TempData["Message"] = "Login failed.";
            return RedirectToPage(AuthenticationForm.LoginFailurePage,
                                  new {Area = AuthenticationForm.LoginFailureArea});
        }

    }
}