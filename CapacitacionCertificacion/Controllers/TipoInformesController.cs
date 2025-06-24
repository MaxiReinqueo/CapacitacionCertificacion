using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapacitacionCertificacion.Models;

namespace CapacitacionCertificacion.Controllers
{
    public class TipoInformesController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public TipoInformesController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: TipoInformes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoInformes.ToListAsync());
        }

        // GET: TipoInformes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInforme = await _context.TipoInformes
                .FirstOrDefaultAsync(m => m.IdTipoInforme == id);
            if (tipoInforme == null)
            {
                return NotFound();
            }

            return View(tipoInforme);
        }

        // GET: TipoInformes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoInformes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoInforme,NombreTipo")] TipoInforme tipoInforme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInforme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInforme);
        }

        // GET: TipoInformes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInforme = await _context.TipoInformes.FindAsync(id);
            if (tipoInforme == null)
            {
                return NotFound();
            }
            return View(tipoInforme);
        }

        // POST: TipoInformes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoInforme,NombreTipo")] TipoInforme tipoInforme)
        {
            if (id != tipoInforme.IdTipoInforme)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInforme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInformeExists(tipoInforme.IdTipoInforme))
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
            return View(tipoInforme);
        }

        // GET: TipoInformes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInforme = await _context.TipoInformes
                .FirstOrDefaultAsync(m => m.IdTipoInforme == id);
            if (tipoInforme == null)
            {
                return NotFound();
            }

            return View(tipoInforme);
        }

        // POST: TipoInformes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoInforme = await _context.TipoInformes.FindAsync(id);
            if (tipoInforme != null)
            {
                _context.TipoInformes.Remove(tipoInforme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInformeExists(int id)
        {
            return _context.TipoInformes.Any(e => e.IdTipoInforme == id);
        }
    }
}
