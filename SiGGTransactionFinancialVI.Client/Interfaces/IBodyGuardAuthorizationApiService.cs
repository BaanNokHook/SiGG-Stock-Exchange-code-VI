using System.Collections.Generic;
using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Common.HttpModels.Authorization;

namespace SiGGTransactionFinancialVI.Client.Interfaces
{
    public interface IBodyGuardAuthorizationApiService
    {

        Task<GetRolesResponse> GetRoles();

        Task<CanResponse> Can(string id,
                              List<string> roles,
                              Dictionary<string, string> claims,
                              bool canAll);

        Task<ManageRoleResponse> AssignRole(string emailAddress,
                                            string role);

        Task<ManageRoleResponse> RevokeRole(string emailAddress,
                                            string role);

    }
}