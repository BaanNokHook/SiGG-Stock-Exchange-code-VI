﻿using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Interfaces;
using SiGGTransactionFinancialVI.Client.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancialVI.Client.Areas.Authentication.Pages
{
    public class ConfirmRegistration : PageModel
    {

        private readonly IBodyGuardAuthenticationApiService _authenticationApiService;

        public ConfirmRegistration(IBodyGuardAuthenticationApiService authenticationApiService)
        {
            _authenticationApiService = authenticationApiService;

        }

        public async Task<IActionResult> OnGet(string token)
        {
            var response = await _authenticationApiService.ConfirmRegistration(token);

            if (response.Success)
            {
                TempData["Message"] = "Confirm registration succeed!";
                return RedirectToPage("/Success", new {Area = "Result"});
            }

            TempData["Message"] = "Confirm registration failed.";
            return RedirectToPage("/Failure", new {Area = "Result"});
        }

    }
}