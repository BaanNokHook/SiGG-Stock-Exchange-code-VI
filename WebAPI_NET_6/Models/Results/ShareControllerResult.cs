using Microsoft.AspNetCore.Mvc;

namespace WebAPI_NET_6.Models.Results
{
    public class ShareControllerResult : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
