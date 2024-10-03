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
    public class SituacoesVendasController : Controller
    {
        private readonly SistemaComandasContext _context;

        public SituacoesVendasController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: SituacoesVendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SituacoesVendas.ToListAsync());
        }

        // GET: SituacoesVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacaoVenda = await _context.SituacoesVendas
                .FirstOrDefaultAsync(m => m.SituacaoVendaId == id);
            if (situacaoVenda == null)
            {
                return NotFound();
            }

            return View(situacaoVenda);
        }

        // GET: SituacoesVendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SituacoesVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SituacaoVendaId,Descricao,Ativo,DataHoraCriacao,DataHoraAlteracao")] SituacaoVenda situacaoVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(situacaoVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(situacaoVenda);
        }

        // GET: SituacoesVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacaoVenda = await _context.SituacoesVendas.FindAsync(id);
            if (situacaoVenda == null)
            {
                return NotFound();
            }
            return View(situacaoVenda);
        }

        // POST: SituacoesVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SituacaoVendaId,Descricao,Ativo,DataHoraCriacao,DataHoraAlteracao")] SituacaoVenda situacaoVenda)
        {
            if (id != situacaoVenda.SituacaoVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(situacaoVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SituacaoVendaExists(situacaoVenda.SituacaoVendaId))
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
            return View(situacaoVenda);
        }

        // GET: SituacoesVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacaoVenda = await _context.SituacoesVendas
                .FirstOrDefaultAsync(m => m.SituacaoVendaId == id);
            if (situacaoVenda == null)
            {
                return NotFound();
            }

            return View(situacaoVenda);
        }

        // POST: SituacoesVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var situacaoVenda = await _context.SituacoesVendas.FindAsync(id);
            if (situacaoVenda != null)
            {
                _context.SituacoesVendas.Remove(situacaoVenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SituacaoVendaExists(int id)
        {
            return _context.SituacoesVendas.Any(e => e.SituacaoVendaId == id);
        }
    }
}
