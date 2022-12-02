using System.Collections.Generic;

namespace SiGGTransactionFinancialVI.Common.HttpModels.Authentication
{
    public class UsersDataResponse : BaseResponse
    {

        public Dictionary<string, string> UsersData { get; set; }

    }
}