using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Interfaces;
using SiGGTransactionFinancialVI.Client.Models.Forms;
using SiGGTransactionFinancialVI.Common.Extensions;
using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancialVI.Client.Areas.Authentication.Pages
{
    public class ValidateRecovery : PageModel
    {

        private readonly IBodyGuardAuthenticationApiService _authenticationApiService;

        public ValidateRecovery(IBodyGuardAuthenticationApiService authenticationApiService)
        {
            _authenticationApiService = authenticationApiService;
        }

        [BindProperty]
        public ValidateRecoveryForm ValidateRecoveryForm { get; set; }

        public void OnGet(string token)
        {
            ValidateRecoveryForm = new ValidateRecoveryForm
            {
                ValidateRecoveryRequest = new ValidateRecoveryRequest
                {
                    Token = token
                }
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData.Set("FormStatus", new FormStatus(ModelState));
                return RedirectToPage(ValidateRecoveryForm.FailurePage,
                                      new {Area = ValidateRecoveryForm.FailureArea});
            }

            var response = await _authenticationApiService.ValidateRecovery
                               (ValidateRecoveryForm.ValidateRecoveryRequest.EmailAddress,
                                ValidateRecoveryForm.ValidateRecoveryRequest.Token,
                                ValidateRecoveryForm.ValidateRecoveryRequest.NewPassword,
                                ValidateRecoveryForm.ValidateRecoveryRequest.NewPasswordConfirm);

            if (response.Success)
            {
                TempData["Message"] = "Recovery validation succeed!";
                return RedirectToPage(ValidateRecoveryForm.SuccessPage,
                                      new {Area = ValidateRecoveryForm.SuccessArea});
            }

            TempData["Message"] = "Recovery validation failed.";
            return RedirectToPage(ValidateRecoveryForm.FailurePage,
                                  new {Area = ValidateRecoveryForm.FailureArea});
        }

    }
}