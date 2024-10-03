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
    public class ComandasController : Controller
    {
        private readonly SistemaComandasContext _context;

        public ComandasController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: Comandas
        public async Task<IActionResult> Index()
        {
            var sistemaComandasContext = _context.Comandas.Include(c => c.Cozinha).Include(c => c.SituacaoComanda).Include(c => c.Venda);
            return View(await sistemaComandasContext.ToListAsync());
        }

        // GET: Comandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas
                .Include(c => c.Cozinha)
                .Include(c => c.SituacaoComanda)
                .Include(c => c.Venda)
                .FirstOrDefaultAsync(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comandas/Create
        public IActionResult Create()
        {
            ViewData["CozinhaId"] = new SelectList(_context.Cozinhas, "CozinhaId", "Descricao");
            ViewData["SituacaoComandaId"] = new SelectList(_context.SituacoesComandas, "SituacaoComandaId", "Descricao");
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente");
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComandaId,VendaId,CozinhaId,SituacaoComandaId,Viagem,DataHoraCriacao,DataHoraAlteracao")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CozinhaId"] = new SelectList(_context.Cozinhas, "CozinhaId", "Descricao", comanda.CozinhaId);
            ViewData["SituacaoComandaId"] = new SelectList(_context.SituacoesComandas, "SituacaoComandaId", "Descricao", comanda.SituacaoComandaId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente", comanda.VendaId);
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            ViewData["CozinhaId"] = new SelectList(_context.Cozinhas, "CozinhaId", "Descricao", comanda.CozinhaId);
            ViewData["SituacaoComandaId"] = new SelectList(_context.SituacoesComandas, "SituacaoComandaId", "Descricao", comanda.SituacaoComandaId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente", comanda.VendaId);
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComandaId,VendaId,CozinhaId,SituacaoComandaId,Viagem,DataHoraCriacao,DataHoraAlteracao")] Comanda comanda)
        {
            if (id != comanda.ComandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.ComandaId))
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
            ViewData["CozinhaId"] = new SelectList(_context.Cozinhas, "CozinhaId", "Descricao", comanda.CozinhaId);
            ViewData["SituacaoComandaId"] = new SelectList(_context.SituacoesComandas, "SituacaoComandaId", "Descricao", comanda.SituacaoComandaId);
            ViewData["VendaId"] = new SelectList(_context.Vendas, "VendaId", "NomeCliente", comanda.VendaId);
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comandas
                .Include(c => c.Cozinha)
                .Include(c => c.SituacaoComanda)
                .Include(c => c.Venda)
                .FirstOrDefaultAsync(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda != null)
            {
                _context.Comandas.Remove(comanda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
            return _context.Comandas.Any(e => e.ComandaId == id);
        }
    }
}
