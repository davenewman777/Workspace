using Microsoft.AspNetCore.Mvc;
using SAPRISE_WAF_Web.Models;

namespace SAPRISE_WAF_Web.Controllers
{
    public class IdentityController : Controller
    {
        public IActionResult Index()
        {
            var model = new IdentityModel
            {
                ExampleField = "Sample Identity Data"
            };
            return View(model);
        }
    }
}
