using Autonomize_Produtos.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomize_Produtos.Models
{

    [Table("Produtos")]

    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Quantidade em estoque")]
        public int QuantidadeEstoque { get; set; }

        [Display(Name = "Descrição do produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço de compra é obrigatório")]
        [Display(Name = "Preço de compra")]
        public int PrecoCompra { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório")]
        [Display(Name = "Preço de venda")]
        public int PrecoVenda  { get; set; }

        [Required(ErrorMessage = "Selecione a catégoria/tipo do produto")]
        [Display(Name = "Tipo")]
        public int TiposProdutoId { get; set; }
        public TiposProduto? TiposProduto { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool Ativo { get; set; }

        [Display(Name = "Valor total de compra em estoque")]
        [NotMapped]
        public int ValorTotalCompra
        { 
            get
            {
                return QuantidadeEstoque * PrecoCompra;
            } 
        }

        [Display(Name = "Valor preterido de venda")]
        [NotMapped]
        public int ValorTotalVenda
        {
            get
            {
                return QuantidadeEstoque * PrecoVenda;
            }
        }

        public ICollection<IncrementarEstoque> Produtos { get; set; }    

    }
}