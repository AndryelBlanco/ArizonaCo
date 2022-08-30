using Lancheria.Context;
using Microsoft.EntityFrameworkCore;

namespace Lancheria.Models
{
    public class CheckoutCart
    {
        private readonly AppDBContext _context;

        public CheckoutCart(AppDBContext context)
        {
            _context = context;
        }

        public string CheckoutCartId { get; set; }
        public List<CheckoutCartItem> CheckoutCartItens { get; set; }
        
        public static CheckoutCart GetCheckoutCart(IServiceProvider services)
        {
            //Define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um servico do tipo do nosso context
            var context = services.GetService<AppDBContext>();

            //Obtem ou gera o ID do carrinho
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessao
            session.SetString("CartId", cartId);

            //Retorna o carrinho com o context e o id atribuido ou obtido
            return new CheckoutCart(context)
            {
                CheckoutCartId = cartId
            };
        }

        public void AddToCart(Burger burger)
        {
            //Single or Default retorna o primeiro elemento que satisfaz a condição
            var checkoutItem = _context.CheckoutCartItem.SingleOrDefault( s => s.Burger.BurgerId == burger.BurgerId && s.CheckoutId == CheckoutCartId);

            if(checkoutItem == null)
            {
                checkoutItem = new CheckoutCartItem
                {
                    CheckoutId = CheckoutCartId,
                    Burger = burger,
                    Ammount = 1
                };
                _context.CheckoutCartItem.Add(checkoutItem);
            }
            else
            {
                checkoutItem.Ammount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Burger burger)
        {
            var checkoutItem = _context.CheckoutCartItem.SingleOrDefault(s => s.Burger.BurgerId == burger.BurgerId && s.CheckoutId == CheckoutCartId);

            var ammountLocal = 0;

            if(checkoutItem != null)
            {
                if(checkoutItem.Ammount > 1)
                {
                    checkoutItem.Ammount--;
                    ammountLocal = checkoutItem.Ammount;
                }
                else
                {
                    _context.CheckoutCartItem.Remove(checkoutItem);
                }
            }

            _context.SaveChanges();
            return ammountLocal;
        }

        public List<CheckoutCartItem> GetCheckoutCartItems()
        {
            return CheckoutCartItens ?? (CheckoutCartItens = _context.CheckoutCartItem.Where(c => c.CheckoutId == CheckoutCartId).Include(s => s.Burger).ToList());
        }

        public void ClearCart()
        {
            var itensFromCart = _context.CheckoutCartItem.Where(cart => cart.CheckoutId == CheckoutCartId);

            _context.CheckoutCartItem.RemoveRange(itensFromCart);
            _context.SaveChanges();

        }

        public decimal GetTotalPrice()
        {
            var total = _context.CheckoutCartItem.Where(c => c.CheckoutId == CheckoutCartId).Select(c => c.Burger.Price * c.Ammount).Sum();
            return total;
        }

    }
}
