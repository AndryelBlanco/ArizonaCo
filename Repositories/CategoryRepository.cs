using Lancheria.Context;
using Lancheria.Models;
using Lancheria.Repositories.Interfaces;

namespace Lancheria.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
