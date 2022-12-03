using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class EndusersService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
