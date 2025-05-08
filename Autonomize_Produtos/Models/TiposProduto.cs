using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomize_Produtos.Models
{
    [Table("TiposProdutos")]
    public class TiposProduto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo do produto")]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Produto>? Produtos { get; set; } 
    }
}
