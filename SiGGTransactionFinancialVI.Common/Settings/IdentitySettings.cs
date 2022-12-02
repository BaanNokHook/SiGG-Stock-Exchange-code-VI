using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiGGTransactionFinancialVI.Common.Settings
{
    public class IdentitySettings
    {

        [JsonProperty("AdditionalClaims")]
        public List<string> AdditionalClaims { get; set; } = new List<string>();

        [JsonProperty("CustomRoles")]
        public List<string> CustomRoles { get; set; } = new List<string>();

        [JsonProperty("EnabledUserDataProperties")]
        public List<string> EnabledUserDataProperties { get; set; } = new List<string>();

    }
}