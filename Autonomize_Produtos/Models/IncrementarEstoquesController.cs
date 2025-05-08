using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Autonomize_Produtos.Models
{
    public class IncrementarEstoquesController : Controller
    {
        private readonly AppDbContext _context;

        public IncrementarEstoquesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: IncrementarEstoques
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.IncrementarEstoques.Include(i => i.Produto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: IncrementarEstoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incrementarEstoque = await _context.IncrementarEstoques
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incrementarEstoque == null)
            {
                return NotFound();
            }

            return View(incrementarEstoque);
        }

        // GET: IncrementarEstoques/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: IncrementarEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,ProdutoId,Operacao")] IncrementarEstoque incrementarEstoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incrementarEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", incrementarEstoque.ProdutoId);
            return View(incrementarEstoque);
        }

        // GET: IncrementarEstoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incrementarEstoque = await _context.IncrementarEstoques.FindAsync(id);
            if (incrementarEstoque == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", incrementarEstoque.ProdutoId);
            return View(incrementarEstoque);
        }

        // POST: IncrementarEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,ProdutoId,Operacao")] IncrementarEstoque incrementarEstoque)
        {
            if (id != incrementarEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incrementarEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncrementarEstoqueExists(incrementarEstoque.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", incrementarEstoque.ProdutoId);
            return View(incrementarEstoque);
        }

        // GET: IncrementarEstoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incrementarEstoque = await _context.IncrementarEstoques
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incrementarEstoque == null)
            {
                return NotFound();
            }

            return View(incrementarEstoque);
        }

        // POST: IncrementarEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incrementarEstoque = await _context.IncrementarEstoques.FindAsync(id);
            if (incrementarEstoque != null)
            {
                _context.IncrementarEstoques.Remove(incrementarEstoque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncrementarEstoqueExists(int id)
        {
            return _context.IncrementarEstoques.Any(e => e.Id == id);
        }
    }
}
