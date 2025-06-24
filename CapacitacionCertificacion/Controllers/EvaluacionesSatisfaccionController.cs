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
    public class EvaluacionesSatisfaccionController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public EvaluacionesSatisfaccionController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: EvaluacionesSatisfaccion
        public async Task<IActionResult> Index()
        {
            var capacitacionCertificacionContext = _context.EvaluacionesSatisfaccions.Include(e => e.IdAsignNavigation);
            return View(await capacitacionCertificacionContext.ToListAsync());
        }

        // GET: EvaluacionesSatisfaccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacionesSatisfaccion = await _context.EvaluacionesSatisfaccions
                .Include(e => e.IdAsignNavigation)
                .FirstOrDefaultAsync(m => m.IdEva == id);
            if (evaluacionesSatisfaccion == null)
            {
                return NotFound();
            }

            return View(evaluacionesSatisfaccion);
        }

        // GET: EvaluacionesSatisfaccion/Create
        public IActionResult Create()
        {
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign");
            return View();
        }

        // POST: EvaluacionesSatisfaccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEva,IdAsign,Puntaje,Comentario,FechaEva")] EvaluacionesSatisfaccion evaluacionesSatisfaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacionesSatisfaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign", evaluacionesSatisfaccion.IdAsign);
            return View(evaluacionesSatisfaccion);
        }

        // GET: EvaluacionesSatisfaccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacionesSatisfaccion = await _context.EvaluacionesSatisfaccions.FindAsync(id);
            if (evaluacionesSatisfaccion == null)
            {
                return NotFound();
            }
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign", evaluacionesSatisfaccion.IdAsign);
            return View(evaluacionesSatisfaccion);
        }

        // POST: EvaluacionesSatisfaccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEva,IdAsign,Puntaje,Comentario,FechaEva")] EvaluacionesSatisfaccion evaluacionesSatisfaccion)
        {
            if (id != evaluacionesSatisfaccion.IdEva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacionesSatisfaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionesSatisfaccionExists(evaluacionesSatisfaccion.IdEva))
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
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign", evaluacionesSatisfaccion.IdAsign);
            return View(evaluacionesSatisfaccion);
        }

        // GET: EvaluacionesSatisfaccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacionesSatisfaccion = await _context.EvaluacionesSatisfaccions
                .Include(e => e.IdAsignNavigation)
                .FirstOrDefaultAsync(m => m.IdEva == id);
            if (evaluacionesSatisfaccion == null)
            {
                return NotFound();
            }

            return View(evaluacionesSatisfaccion);
        }

        // POST: EvaluacionesSatisfaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacionesSatisfaccion = await _context.EvaluacionesSatisfaccions.FindAsync(id);
            if (evaluacionesSatisfaccion != null)
            {
                _context.EvaluacionesSatisfaccions.Remove(evaluacionesSatisfaccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionesSatisfaccionExists(int id)
        {
            return _context.EvaluacionesSatisfaccions.Any(e => e.IdEva == id);
        }
    }
}
