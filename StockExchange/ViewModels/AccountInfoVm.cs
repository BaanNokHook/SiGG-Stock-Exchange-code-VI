using StockExchange.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockExchange.API.ViewModels
{
    public class ResponseVm
    {
        internal object Accept;
        internal object Authorization;

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public String Message { get; set; }
    }
}
