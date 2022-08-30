using Lancheria.Models;
using Lancheria.Repositories.Interfaces;
using Lancheria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lancheria.Controllers
{
    public class CheckoutCartController : Controller
    {
        //para acessar os lanches e o carrinho de compras, precisamos injetar a instancia do nosso repositorio de lanches
        private readonly IBurgerRepository _burgerRepository;
        private readonly CheckoutCart _checkoutCart;

        public CheckoutCartController(IBurgerRepository burgerRepository, CheckoutCart checkoutCart)
        {
            _burgerRepository = burgerRepository;
            _checkoutCart = checkoutCart;
        }

        public IActionResult Index()
        {
            var itens = _checkoutCart.GetCheckoutCartItems();
            _checkoutCart.CheckoutCartItens = itens;
            var checkoutViewModel = new CheckoutCartViewModel
            {
                CheckoutCart = _checkoutCart,
                CheckoutCartTotal = _checkoutCart.GetTotalPrice(),
            };

            return View(checkoutViewModel);
        }

        //É redirectToActionResult pois vamos redirecionar para Index com o nosso item
        public IActionResult AddItemInCheckoutCart(int burgerId)
        {
            var SelectedBurger = _burgerRepository.Burgers.FirstOrDefault(p => p.BurgerId == burgerId);
            if(SelectedBurger != null)
            {
                _checkoutCart.AddToCart(SelectedBurger);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemFromCheckoutCart(int burgerId)
        {
            var SelectedBurger = _burgerRepository.Burgers.FirstOrDefault(p => p.BurgerId == burgerId);
            if (SelectedBurger != null)
            {
                _checkoutCart.RemoveFromCart(SelectedBurger);
            }
            return RedirectToAction("Index");
        }
    }
}
