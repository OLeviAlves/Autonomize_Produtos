using Autonomize_Produtos.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autonomize_Produtos.Models
{
    public class IncrementarEstoque
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que 0")]
        public int Quantidade { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Obrigatório informar o produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Selecione a operação")]
        [Display(Name = "Tipo de operação")]
        public TipoOperacaoEstoque Operacao { get; set; }
    }

    public enum TipoOperacaoEstoque
    {
        Adicionar,
        Remover
    }
}

