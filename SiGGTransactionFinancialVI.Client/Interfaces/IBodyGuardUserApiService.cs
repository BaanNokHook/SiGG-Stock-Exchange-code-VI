using System.Collections.Generic;
using System.Threading.Tasks;
using SiGGTransactionFinancialVI.Client.Models.Lists;
using SiGGTransactionFinancialVI.Common.HttpModels.Authentication;
using SiGGTransactionFinancialVI.Common.Models;

namespace SiGGTransactionFinancialVI.Client.Interfaces
{
    public interface IBodyGuardUserApiService
    {

        public Task<List<User>> GetUsers();

        public Task<User> GetUser(string id);

        public Task<UserUpdateResponse> UpdateUser(User user);

        public Task<UserDeleteResponse> DeleteUser(string id);

    }
}