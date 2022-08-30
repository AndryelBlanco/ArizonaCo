using Lancheria.Models;
using Microsoft.EntityFrameworkCore;

namespace Lancheria.Context
{
    //Herdamos do DBContext
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        //Mapeamento de classes para tabelas que o EntityFramework Core vai criar
        public DbSet<Category> Categories { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<CheckoutCartItem> CheckoutCartItem { get; set; }

    }
}
