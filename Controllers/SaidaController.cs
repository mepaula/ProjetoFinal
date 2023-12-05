using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class SaidaController : Controller
    {
        private readonly Contexto _context;

        public SaidaController(Contexto context)
        {
            _context = context;
        }

        // GET: Saida
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Saida.Include(s => s.Produto).Include(s => s.TipoSaida).Include(s => s.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Saida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Saida == null)
            {
                return NotFound();
            }

            var saida = await _context.Saida
                .Include(s => s.Produto)
                .Include(s => s.TipoSaida)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saida == null)
            {
                return NotFound();
            }

            return View(saida);
        }

        // GET: Saida/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId");
            ViewData["TipoSaidaId"] = new SelectList(_context.TipoSaida, "TipoSaidaId", "TipoSaidaId");
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Saida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaidaId,ProdutoId,ProdutoEstoque,QuantidadeSaidaId,UsuarioId,CleinteId,TipoSaidaId")] Saida saida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", saida.ProdutoId);
            ViewData["TipoSaidaId"] = new SelectList(_context.TipoSaida, "TipoSaidaId", "TipoSaidaId", saida.TipoSaidaId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "UsuarioId", saida.UsuarioId);
            return View(saida);
        }

        // GET: Saida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Saida == null)
            {
                return NotFound();
            }

            var saida = await _context.Saida.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", saida.ProdutoId);
            ViewData["TipoSaidaId"] = new SelectList(_context.TipoSaida, "TipoSaidaId", "TipoSaidaId", saida.TipoSaidaId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "UsuarioId", saida.UsuarioId);
            return View(saida);
        }

        // POST: Saida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaidaId,ProdutoId,ProdutoEstoque,QuantidadeSaidaId,UsuarioId,CleinteId,TipoSaidaId")] Saida saida)
        {
            if (id != saida.SaidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaExists(saida.SaidaId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoId", saida.ProdutoId);
            ViewData["TipoSaidaId"] = new SelectList(_context.TipoSaida, "TipoSaidaId", "TipoSaidaId", saida.TipoSaidaId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<Usuario>(), "UsuarioId", "UsuarioId", saida.UsuarioId);
            return View(saida);
        }

        // GET: Saida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Saida == null)
            {
                return NotFound();
            }

            var saida = await _context.Saida
                .Include(s => s.Produto)
                .Include(s => s.TipoSaida)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saida == null)
            {
                return NotFound();
            }

            return View(saida);
        }

        // POST: Saida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Saida == null)
            {
                return Problem("Entity set 'Contexto.Saida'  is null.");
            }
            var saida = await _context.Saida.FindAsync(id);
            if (saida != null)
            {
                _context.Saida.Remove(saida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaidaExists(int id)
        {
          return (_context.Saida?.Any(e => e.SaidaId == id)).GetValueOrDefault();
        }
    }
}
