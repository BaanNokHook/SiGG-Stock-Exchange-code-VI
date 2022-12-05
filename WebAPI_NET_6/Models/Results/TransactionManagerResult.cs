using Microsoft.AspNetCore.Mvc;

namespace WebAPI_NET_6.Models.Results
{
    public class TransactionManagerResult : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
