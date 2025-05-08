using Autonomize_Produtos.Controllers;
using Microsoft.EntityFrameworkCore;
using Autonomize_Produtos.Models;

namespace Autonomize_Produtos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TiposProduto> TipoProdutos { get;set; }
        public DbSet<Autonomize_Produtos.Models.IncrementarEstoque> IncrementarEstoque { get; set; }
    }
}
