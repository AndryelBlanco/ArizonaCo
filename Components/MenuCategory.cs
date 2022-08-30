using Lancheria.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lancheria.Components
{
    public class MenuCategory : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public MenuCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var category = _categoryRepository.Categories.OrderBy(c => c.CategoryName);
            return View(category);
        }
    }
}
