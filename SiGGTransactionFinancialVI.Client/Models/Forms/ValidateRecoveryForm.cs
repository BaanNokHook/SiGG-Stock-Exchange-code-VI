﻿using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;

namespace SiGGTransactionFinancialVI.Client.Models.Forms
{
    public class ValidateRecoveryForm
    {

        public ValidateRecoveryRequest ValidateRecoveryRequest { get; set; }

        public string SuccessArea { get; set; } = "Result";

        public string SuccessPage { get; set; } = "/Success";

        public string FailureArea { get; set; } = "Authentication";

        public string FailurePage { get; set; } = "/ValidateRecovery";

        public string SubmitLabel { get; set; } = "submit_password_change";

    }
}