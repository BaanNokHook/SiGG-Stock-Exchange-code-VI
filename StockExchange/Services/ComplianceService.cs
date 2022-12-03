using Microsoft.AspNetCore.Mvc;

namespace StockExchange.API.Services
{
    public class ComplianceService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
