using Microsoft.AspNetCore.Mvc;
using SAPRISE_WAF_Web.Models;

namespace SAPRISE_WAF_Web.Controllers
{
    public class NetworkingController : Controller
    {
        public IActionResult Index()
        {
            var model = new NetworkingModel
            {
                ExampleField = "Sample Networking Data"
            };
            return View(model);
        }
    }
}
