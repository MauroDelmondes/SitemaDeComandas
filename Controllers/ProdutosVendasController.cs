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
    public class ProdutosVendasController : Controller
    {
        private readonly SistemaComandasContext _context;

        public ProdutosVendasController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: ProdutosVendas
        public async Task<IActionResult> Index()
        {
            var sistemaComandasContext = _context.ProdutosVendas.Include(p => p.Produto).Include(p => p.Venda);
            return View(await sistemaComandasContext.ToListAsync());
        }

        // GET: ProdutosVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoVenda = await _context.ProdutosVendas
                .Include(p => p.Produto)
                .Include(p => p.Venda)
                .FirstOrDefaultAsync(m => m.ProdutoVendaId == id);
            if (produtoVenda == null)
            {
                return NotFound();
            }

            return View(produtoVenda);
        }

        // GET: ProdutosVendas/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente");
            return View();
        }

        // POST: ProdutosVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoVendaId,VendaId,ProdutoId,Quantidade,PrecoUnitario,PrecoTotal")] ProdutoVenda produtoVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente", produtoVenda.VendaId);
            return View(produtoVenda);
        }

        // GET: ProdutosVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoVenda = await _context.ProdutosVendas.FindAsync(id);
            if (produtoVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente", produtoVenda.VendaId);
            return View(produtoVenda);
        }

        // POST: ProdutosVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoVendaId,VendaId,ProdutoId,Quantidade,PrecoUnitario,PrecoTotal")] ProdutoVenda produtoVenda)
        {
            if (id != produtoVenda.ProdutoVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoVendaExists(produtoVenda.ProdutoVendaId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente", produtoVenda.VendaId);
            return View(produtoVenda);
        }

        // GET: ProdutosVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoVenda = await _context.ProdutosVendas
                .Include(p => p.Produto)
                .Include(p => p.Venda)
                .FirstOrDefaultAsync(m => m.ProdutoVendaId == id);
            if (produtoVenda == null)
            {
                return NotFound();
            }

            return View(produtoVenda);
        }

        // POST: ProdutosVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoVenda = await _context.ProdutosVendas.FindAsync(id);
            if (produtoVenda != null)
            {
                _context.ProdutosVendas.Remove(produtoVenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoVendaExists(int id)
        {
            return _context.ProdutosVendas.Any(e => e.ProdutoVendaId == id);
        }
    }
}
