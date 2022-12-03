using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class DirectDebitService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
