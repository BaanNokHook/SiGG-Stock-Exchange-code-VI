using StockExchange.Domain.Common;

namespace StockExchange.Domain.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        User GetById(long id);
    }
}