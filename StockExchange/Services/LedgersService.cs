using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class LedgersService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
