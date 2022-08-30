using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lancheria.Models
{
    [Table("CheckoutCartItem")]
    public class CheckoutCartItem
    {
        public int CheckoutCartItemId { get; set; }
        public Burger Burger { get; set; }
        public int Ammount { get; set; }
        [StringLength(200)]
        public string CheckoutId { get; set; }
    }
}
