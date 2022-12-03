using StockExchange.Domain.Common;

namespace StockExchange.Domain.AccountAggregate
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Account GetById(int id);
    }
}