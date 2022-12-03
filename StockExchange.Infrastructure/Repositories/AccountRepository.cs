using StockExchange.Domain;
using StockExchange.Domain.AccountAggregate;
using StockExchange.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace StockExchange.Infrastructure.Repositories
{
    public class AccountRepository : IBankRepository
    {
        private readonly IEnumerable<Bank> _accounts;

        public AccountRepository()
        {
            _accounts = AccountInit.GetAllAccounts();
        }

        public Bank GetById(int id)
        {
            return _accounts.SingleOrDefault(x => x.Id == id);
        }
    }
}