using Microsoft.AspNetCore.Mvc;

namespace HelperLand.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult ServiceRequest()
        {
            return View();
        }
    }
}
