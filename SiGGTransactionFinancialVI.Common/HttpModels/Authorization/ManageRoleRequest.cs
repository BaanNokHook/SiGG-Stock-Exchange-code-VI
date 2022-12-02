using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SiGGTransactionFinancialVI.Common.HttpModels.Authorization
{
    public class ManageRoleRequest
    {
        [Required]
        [JsonRequired]
        [Display(Name = "email_address")]
        public string EmailAddress { get; set; }
        
        [Required]
        [JsonRequired]
        [Display(Name = "role")]
        public string Role { get; set; }

    }
}