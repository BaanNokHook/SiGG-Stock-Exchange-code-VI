using Microsoft.AspNetCore.Mvc;

namespace WebAPI_NET_6.Models.Results
{
    public class TaxServiceResult : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
