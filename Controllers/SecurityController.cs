using Microsoft.AspNetCore.Mvc;
using SAPRISE_WAF_Web.Models;

namespace SAPRISE_WAF_Web.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            var model = new SecurityModel
            {
                ExampleField = "Sample Security Data"
            };
            return View(model);
        }
    }
}
