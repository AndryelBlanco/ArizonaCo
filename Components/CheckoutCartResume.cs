using Lancheria.Models;
using Lancheria.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lancheria.Components
{
    public class CheckoutCartResume : ViewComponent
    {
        //Injetar instancia do carrinho compras
        private readonly CheckoutCart _checkoutCart;

        public CheckoutCartResume(CheckoutCart checkoutCart)
        {
            _checkoutCart = checkoutCart;
        }

        public IViewComponentResult Invoke()
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
    }
}
