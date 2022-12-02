using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SiGGTransactionFinancialVI.Common.HttpModels.Authorization
{
    public class GetRolesResponse : BaseResponse
    {

        public List<SelectListItem> Roles { get; set; }

    }
}