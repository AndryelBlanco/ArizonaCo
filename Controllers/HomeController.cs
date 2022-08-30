using Lancheria.Models;
using Lancheria.Repositories.Interfaces;
using Lancheria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lancheria.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBurgerRepository _burgerRepository;

        public HomeController(IBurgerRepository burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                AwesomeBurgers = _burgerRepository.AwesomeBurgers
            };
            return View(homeVM);
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}