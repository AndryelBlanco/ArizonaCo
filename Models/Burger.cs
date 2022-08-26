using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lancheria.Models
{
    [Table("Burgers")]
    public class Burger
    {
        [Key]
        [Required(ErrorMessage="Esse campo deve ser informado!")]
        public int BurgerId { get; set; }

        [Required(ErrorMessage="Esse campo deve ser informado!")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O nome deve ter no máximo 80 caracteres e no mínimo 10 caracteres!")]
        public string BurgerName { get; set; }
        
        [Required(ErrorMessage="Esse campo deve ser informado!")]
        [Display(Name = "Descrição Curta")]
        [MinLength(20, ErrorMessage="A descrição curta deve ter no mínimo 20 caracteres!")]
        [MaxLength(100, ErrorMessage = "A descrição curta deve ter no máximo 100 caracteres!")]
        public string DescriptionTiny { get; set; }

        [Required(ErrorMessage="Esse campo deve ser informado!")]
        [Display(Name = "Descrição Completa")]
        [MinLength(50, ErrorMessage = "A descrição curta deve ter no mínimo 50 caracteres!")]
        [MaxLength(300, ErrorMessage = "A descrição curta deve ter no máximo 300 caracteres!")]
        public string DescriptionComplete { get; set; }

        [Required(ErrorMessage="Esse campo deve ser informado!")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Price { get; set; }

        [Required(ErrorMessage="Esse campo deve ser informado!")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage="Esse campo deve ser informado!")]
        public string ThumbNailUrl { get; set; }

        [Display(Name = "É favorito ?")]
        public bool IsAwesome { get; set; }

        [Display(Name = "Está disponível ?")]
        [Required(ErrorMessage="Esse campo deve ser informado!")]
        public bool Available { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public DateTime DataDeCriacao  { get; set; }

        public virtual Category Category { get; set; }

    }
}
