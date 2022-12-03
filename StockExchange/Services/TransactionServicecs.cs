using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class TransactionServicecs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
