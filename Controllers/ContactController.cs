using Microsoft.AspNetCore.Mvc;

namespace Lancheria.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
