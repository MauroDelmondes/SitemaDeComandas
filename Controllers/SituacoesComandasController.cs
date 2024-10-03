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
    public class SituacoesComandasController : Controller
    {
        private readonly SistemaComandasContext _context;

        public SituacoesComandasController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: SituacoesComandas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SituacoesComandas.ToListAsync());
        }

        // GET: SituacoesComandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacaoComanda = await _context.SituacoesComandas
                .FirstOrDefaultAsync(m => m.SituacaoComandaId == id);
            if (situacaoComanda == null)
            {
                return NotFound();
            }

            return View(situacaoComanda);
        }

        // GET: SituacoesComandas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SituacoesComandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SituacaoComandaId,Descricao,Ativo,DataHoraCriacao,DataHoraAlteracao")] SituacaoComanda situacaoComanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(situacaoComanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(situacaoComanda);
        }

        // GET: SituacoesComandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacaoComanda = await _context.SituacoesComandas.FindAsync(id);
            if (situacaoComanda == null)
            {
                return NotFound();
            }
            return View(situacaoComanda);
        }

        // POST: SituacoesComandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SituacaoComandaId,Descricao,Ativo,DataHoraCriacao,DataHoraAlteracao")] SituacaoComanda situacaoComanda)
        {
            if (id != situacaoComanda.SituacaoComandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(situacaoComanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SituacaoComandaExists(situacaoComanda.SituacaoComandaId))
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
            return View(situacaoComanda);
        }

        // GET: SituacoesComandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var situacaoComanda = await _context.SituacoesComandas
                .FirstOrDefaultAsync(m => m.SituacaoComandaId == id);
            if (situacaoComanda == null)
            {
                return NotFound();
            }

            return View(situacaoComanda);
        }

        // POST: SituacoesComandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var situacaoComanda = await _context.SituacoesComandas.FindAsync(id);
            if (situacaoComanda != null)
            {
                _context.SituacoesComandas.Remove(situacaoComanda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SituacaoComandaExists(int id)
        {
            return _context.SituacoesComandas.Any(e => e.SituacaoComandaId == id);
        }
    }
}
