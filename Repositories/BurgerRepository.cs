using Lancheria.Context;
using Lancheria.Models;
using Lancheria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lancheria.Repositories
{
    public class BurgerRepository : IBurgerRepository
    {
        private readonly AppDBContext _context;
        public BurgerRepository(AppDBContext context) 
        {
            _context = context;
        }

        public IEnumerable<Burger> Burgers => _context.Burger.Include(c => c.Category);

        public IEnumerable<Burger> AwesomeBurgers => _context.Burger.Where(b => b.IsAwesome).Include(c => c.Category);

        public Burger GetBurgerById(int BurgerId)
        {
            return _context.Burger.FirstOrDefault(b => b.BurgerId == BurgerId);
        }
    }
}
