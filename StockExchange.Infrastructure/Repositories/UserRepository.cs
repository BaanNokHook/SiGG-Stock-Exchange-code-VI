
using StockExchange.Domain;
using StockExchange.Domain.UserAggregate;
using StockExchange.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;


namespace StockExchange.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IEnumerable<User> _users;


        public UserRepository()
        {
            _users = UsersInit.GetAllUsers();
          
        }

        public User GetById(long id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }
    }
}
