using System.ComponentModel.DataAnnotations;
using SiGGTransactionFinancialVI.Common.Attributes;
using Newtonsoft.Json;

namespace SiGGTransactionFinancialVI.Common.HttpModels.Authentication
{
    public class ConfirmRegistrationRequest
    {

        [Required]
        [JsonRequired]
        public string Token { get; set; }

    }
}