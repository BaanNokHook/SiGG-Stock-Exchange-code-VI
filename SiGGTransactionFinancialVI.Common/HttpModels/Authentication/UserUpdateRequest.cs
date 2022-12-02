using SiGGTransactionFinancialVI.Common.Models;

namespace SiGGTransactionFinancialVI.Common.HttpModels.Authentication
{
    public class UserUpdateRequest
    {

        public string Id { get; set; }

        public User UserData { get; set; }

    }
}