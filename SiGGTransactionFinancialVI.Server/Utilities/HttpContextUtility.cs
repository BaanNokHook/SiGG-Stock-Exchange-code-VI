﻿using System.Linq;
using System.Security.Claims;
using SiGGTransactionFinancialVI.Common.BaseClasses;

namespace SiGGTransactionFinancialVI.Server.Utilities
{
    public class HttpContextUtility : InjectedHttpContextBaseStaticClass
    {

        public static string LoggedUserIdentityId()
        {
            if (!(HttpContext.User.Identity is ClaimsIdentity identity) || !identity.IsAuthenticated) return null;
            return (from claim in identity.Claims
                    where new[] {"sub", ClaimTypes.NameIdentifier}.Contains(claim.Type)
                    select claim.Value).FirstOrDefault();
        }

    }
}