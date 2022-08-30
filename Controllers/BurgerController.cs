using Lancheria.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Lancheria.ViewModels;
using Lancheria.Models;

namespace Lancheria.Controllers
{
    public class BurgerController : Controller
    {
        private readonly IBurgerRepository _BurgerRepository;

        public BurgerController(IBurgerRepository burgerRepository)
        {
            _BurgerRepository = burgerRepository;
        }

        public IActionResult List(string selectedCategory)
        {
            IEnumerable<Burger> burgers;
            string currentCategory = string.Empty;
            
            if (string.IsNullOrEmpty(selectedCategory))
            {
                burgers = _BurgerRepository.Burgers.OrderBy(l => l.BurgerId);
                currentCategory = "Todos os Burgers";
            }
            else
            {

                burgers = _BurgerRepository.Burgers
                          .Where(l => l.Category.CategoryName.Equals(selectedCategory))
                          .OrderBy(c => c.BurgerName);

                currentCategory = selectedCategory;
            }

            var burgerListViewModel = new BurgerListViewModel
            {
                Burgers = burgers,
                CurrentCategory = currentCategory,
            };

            return View(burgerListViewModel);

        }
    }
}
