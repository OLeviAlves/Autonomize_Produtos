using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autonomize_Produtos.Models;

namespace Autonomize_Produtos.Controllers
{
    public class TiposProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public TiposProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TiposProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProdutos.ToListAsync());
        }

        // GET: TiposProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProduto = await _context.TipoProdutos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposProduto == null)
            {
                return NotFound();
            }

            return View(tiposProduto);
        }

        // GET: TiposProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TiposProduto tiposProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposProduto);
        }

        // GET: TiposProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProduto = await _context.TipoProdutos.FindAsync(id);
            if (tiposProduto == null)
            {
                return NotFound();
            }
            return View(tiposProduto);
        }

        // POST: TiposProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TiposProduto tiposProduto)
        {
            if (id != tiposProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposProdutoExists(tiposProduto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tiposProduto);
        }

        // GET: TiposProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProduto = await _context.TipoProdutos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposProduto == null)
            {
                return NotFound();
            }

            return View(tiposProduto);
        }

        // POST: TiposProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposProduto = await _context.TipoProdutos.FindAsync(id);
            if (tiposProduto != null)
            {
                _context.TipoProdutos.Remove(tiposProduto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.Id == id);
        }
    }
}
