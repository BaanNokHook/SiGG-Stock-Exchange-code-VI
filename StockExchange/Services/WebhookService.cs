using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class WebhookService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
