using StockExchange.Domain.Common;

namespace StockExchange.Domain.AccountAggregate
{
    public interface IBankRepository : IRepository<Bank>
    {
        public Bank GetById(int id);
    }
}