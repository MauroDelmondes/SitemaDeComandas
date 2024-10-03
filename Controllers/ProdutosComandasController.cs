using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SitemaDeComandas.Context;
using SitemaDeComandas.Models;

namespace SitemaDeComandas.Controllers
{
    public class ProdutosComandasController : Controller
    {
        private readonly SistemaComandasContext _context;

        public ProdutosComandasController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: ProdutosComandas
        public async Task<IActionResult> Index()
        {
            var sistemaComandasContext = _context.ProdutosComandas.Include(p => p.Comanda).Include(p => p.Produto);
            return View(await sistemaComandasContext.ToListAsync());
        }

        // GET: ProdutosComandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoComanda = await _context.ProdutosComandas
                .Include(p => p.Comanda)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PratoComandaId == id);
            if (produtoComanda == null)
            {
                return NotFound();
            }

            return View(produtoComanda);
        }

        // GET: ProdutosComandas/Create
        public IActionResult Create()
        {
            ViewData["ComandaId"] = new SelectList(_context.Comandas, "ComandaId", "ComandaId");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: ProdutosComandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PratoComandaId,ProdutoId,ComandaId")] ProdutoComanda produtoComanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoComanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComandaId"] = new SelectList(_context.Comandas, "ComandaId", "ComandaId", produtoComanda.ComandaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoComanda.ProdutoId);
            return View(produtoComanda);
        }

        // GET: ProdutosComandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoComanda = await _context.ProdutosComandas.FindAsync(id);
            if (produtoComanda == null)
            {
                return NotFound();
            }
            ViewData["ComandaId"] = new SelectList(_context.Comandas, "ComandaId", "ComandaId", produtoComanda.ComandaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoComanda.ProdutoId);
            return View(produtoComanda);
        }

        // POST: ProdutosComandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PratoComandaId,ProdutoId,ComandaId")] ProdutoComanda produtoComanda)
        {
            if (id != produtoComanda.PratoComandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoComanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoComandaExists(produtoComanda.PratoComandaId))
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
            ViewData["ComandaId"] = new SelectList(_context.Comandas, "ComandaId", "ComandaId", produtoComanda.ComandaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoComanda.ProdutoId);
            return View(produtoComanda);
        }

        // GET: ProdutosComandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoComanda = await _context.ProdutosComandas
                .Include(p => p.Comanda)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PratoComandaId == id);
            if (produtoComanda == null)
            {
                return NotFound();
            }

            return View(produtoComanda);
        }

        // POST: ProdutosComandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoComanda = await _context.ProdutosComandas.FindAsync(id);
            if (produtoComanda != null)
            {
                _context.ProdutosComandas.Remove(produtoComanda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoComandaExists(int id)
        {
            return _context.ProdutosComandas.Any(e => e.PratoComandaId == id);
        }
    }
}
