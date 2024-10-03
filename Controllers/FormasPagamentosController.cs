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
    public class FormasPagamentosController : Controller
    {
        private readonly SistemaComandasContext _context;

        public FormasPagamentosController(SistemaComandasContext context)
        {
            _context = context;
        }

        // GET: FormasPagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormasPagamentos.ToListAsync());
        }

        // GET: FormasPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormasPagamentos
                .FirstOrDefaultAsync(m => m.FormaPagamentoId == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // GET: FormasPagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormasPagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormaPagamentoId,Descricao,Ativo,DataHoraCriacao,DataHoraAlteracao")] FormaPagamento formaPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagamento);
        }

        // GET: FormasPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormasPagamentos.FindAsync(id);
            if (formaPagamento == null)
            {
                return NotFound();
            }
            return View(formaPagamento);
        }

        // POST: FormasPagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormaPagamentoId,Descricao,Ativo,DataHoraCriacao,DataHoraAlteracao")] FormaPagamento formaPagamento)
        {
            if (id != formaPagamento.FormaPagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaPagamentoExists(formaPagamento.FormaPagamentoId))
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
            return View(formaPagamento);
        }

        // GET: FormasPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaPagamento = await _context.FormasPagamentos
                .FirstOrDefaultAsync(m => m.FormaPagamentoId == id);
            if (formaPagamento == null)
            {
                return NotFound();
            }

            return View(formaPagamento);
        }

        // POST: FormasPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaPagamento = await _context.FormasPagamentos.FindAsync(id);
            if (formaPagamento != null)
            {
                _context.FormasPagamentos.Remove(formaPagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaPagamentoExists(int id)
        {
            return _context.FormasPagamentos.Any(e => e.FormaPagamentoId == id);
        }
    }
}
