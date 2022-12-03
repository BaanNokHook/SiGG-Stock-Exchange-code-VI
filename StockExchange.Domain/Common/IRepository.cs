using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Domain.Common
{
   public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
