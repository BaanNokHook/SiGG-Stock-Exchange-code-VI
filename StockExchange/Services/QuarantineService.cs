using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class QuarantineService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
