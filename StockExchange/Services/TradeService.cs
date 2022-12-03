using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class TradeService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
