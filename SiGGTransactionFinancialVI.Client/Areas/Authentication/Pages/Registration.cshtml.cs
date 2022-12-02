using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Interfaces;
using SiGGTransactionFinancialVI.Client.Models.Forms;
using SiGGTransactionFinancialVI.Common.Extensions;
using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancialVI.Client.Areas.Authentication.Pages
{
    public class Registration : PageModel
    {

        private readonly IBodyGuardAuthenticationApiService _authenticationApiService;

        public Registration(IBodyGuardAuthenticationApiService authenticationApiService)
        {
            _authenticationApiService = authenticationApiService;
        }

        [BindProperty]
        public RegistrationForm RegistrationForm { get; set; }

        public void OnGet()
        {
            RegistrationForm = new RegistrationForm
            {
                SuccessArea = "Authentication",
                SuccessPage = "/Success",
                FailureArea = "Authentication",
                FailurePage = "/Registration",
                SubmitLabel = "Registrati",
                CreateRequest = new UserCreateRequest {UserData = new Common.Models.User()}
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData.Set("FormStatus", new FormStatus(ModelState));
                return RedirectToPage(RegistrationForm.FailurePage,
                                      new {Area = RegistrationForm.FailureArea});
            }

            var response = await _authenticationApiService.Register
                               (RegistrationForm.CreateRequest.EmailAddress,
                                RegistrationForm.CreateRequest.Password,
                                RegistrationForm.CreateRequest.UserData);

            if (response.Success)
            {
                TempData["Message"] = "Registration succeed!";
                return RedirectToPage(RegistrationForm.SuccessPage,
                                      new {Area = RegistrationForm.SuccessArea});
            }

            TempData["Message"] = "Registration failed.";
            return RedirectToPage(RegistrationForm.FailurePage,
                                  new {Area = RegistrationForm.FailureArea});
        }

    }
}