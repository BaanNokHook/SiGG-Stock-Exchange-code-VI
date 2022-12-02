﻿using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;

namespace SiGGTransactionFinancialVI.Client.Models.Forms
{
    public class PasswordRecoveryForm
    {

        public PasswordRecoveryRequest PasswordRecoveryRequest { get; set; }

        public string SuccessArea { get; set; } = "Result";

        public string SuccessPage { get; set; } = "/Success";

        public string FailureArea { get; set; } = "Authentication";

        public string FailurePage { get; set; } = "/PasswordRecovery";

        public string SubmitLabel { get; set; } = "submit_password_recovery";

    }
}