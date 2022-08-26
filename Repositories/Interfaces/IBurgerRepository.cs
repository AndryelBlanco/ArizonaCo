using Lancheria.Models;

namespace Lancheria.Repositories.Interfaces
{
    public interface IBurgerRepository
    {
        IEnumerable<Burger> Burgers { get; }
        IEnumerable<Burger> AwesomeBurgers { get; }
        Burger GetBurgerById(int BurgerId);
    }
}
