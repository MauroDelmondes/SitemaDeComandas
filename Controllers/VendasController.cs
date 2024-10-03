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
    public class VendasController : Controller
    {
        private readonly SistemaComandasContext _context;

        public VendasController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var sistemaComandasContext = _context.Vendas.Include(v => v.FormaPagamento).Include(v => v.SituacaoVenda);
            return View(await sistemaComandasContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.FormaPagamento)
                .Include(v => v.SituacaoVenda)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormasPagamentos, "FormaPagamentoId", "Descricao");
            ViewData["SituacaoVendaId"] = new SelectList(_context.SituacoesVendas, "SituacaoVendaId", "Descricao");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,NomeCliente,FormaPagamentoId,SituacaoVendaId,PrecoTotal,DataHoraVenda,DataHoraAlteracao")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormasPagamentos, "FormaPagamentoId", "Descricao", venda.FormaPagamentoId);
            ViewData["SituacaoVendaId"] = new SelectList(_context.SituacoesVendas, "SituacaoVendaId", "Descricao", venda.SituacaoVendaId);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormasPagamentos, "FormaPagamentoId", "Descricao", venda.FormaPagamentoId);
            ViewData["SituacaoVendaId"] = new SelectList(_context.SituacoesVendas, "SituacaoVendaId", "Descricao", venda.SituacaoVendaId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,NomeCliente,FormaPagamentoId,SituacaoVendaId,PrecoTotal,DataHoraVenda,DataHoraAlteracao")] Venda venda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
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
            ViewData["FormaPagamentoId"] = new SelectList(_context.FormasPagamentos, "FormaPagamentoId", "Descricao", venda.FormaPagamentoId);
            ViewData["SituacaoVendaId"] = new SelectList(_context.SituacoesVendas, "SituacaoVendaId", "Descricao", venda.SituacaoVendaId);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.FormaPagamento)
                .Include(v => v.SituacaoVenda)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.VendaId == id);
        }
    }
}
