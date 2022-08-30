using Lancheria.Models;

namespace Lancheria.ViewModels
{
    public class BurgerListViewModel
    {

        public IEnumerable<Burger> Burgers { get; set; }
        public string CurrentCategory { get; set; }

    }
}
