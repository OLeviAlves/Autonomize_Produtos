using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autonomize_Produtos.Controllers
{
    public IActionResult IncrementarEstoque(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound();
        }

        var viewModel = new IncrementoEstoqueViewModel
        {
            ProdutoId = produto.Id,
            NomeProduto = produto.Nome
        };

        return View(viewModel);
    }
}
