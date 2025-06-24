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
    public class CertificacionesController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public CertificacionesController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: Certificaciones
        public async Task<IActionResult> Index()
        {
            var capacitacionCertificacionContext = _context.Certificaciones.Include(c => c.IdAsignNavigation);
            return View(await capacitacionCertificacionContext.ToListAsync());
        }

        // GET: Certificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificacione = await _context.Certificaciones
                .Include(c => c.IdAsignNavigation)
                .FirstOrDefaultAsync(m => m.IdCert == id);
            if (certificacione == null)
            {
                return NotFound();
            }

            return View(certificacione);
        }

        // GET: Certificaciones/Create
        public IActionResult Create()
        {
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign");
            return View();
        }

        // POST: Certificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCert,IdAsign,FechaEmision,FechaExpiracion,DescripcionCer")] Certificacione certificacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign", certificacione.IdAsign);
            return View(certificacione);
        }

        // GET: Certificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificacione = await _context.Certificaciones.FindAsync(id);
            if (certificacione == null)
            {
                return NotFound();
            }
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign", certificacione.IdAsign);
            return View(certificacione);
        }

        // POST: Certificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCert,IdAsign,FechaEmision,FechaExpiracion,DescripcionCer")] Certificacione certificacione)
        {
            if (id != certificacione.IdCert)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificacioneExists(certificacione.IdCert))
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
            ViewData["IdAsign"] = new SelectList(_context.AsignacionesCursos, "IdAsign", "IdAsign", certificacione.IdAsign);
            return View(certificacione);
        }

        // GET: Certificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificacione = await _context.Certificaciones
                .Include(c => c.IdAsignNavigation)
                .FirstOrDefaultAsync(m => m.IdCert == id);
            if (certificacione == null)
            {
                return NotFound();
            }

            return View(certificacione);
        }

        // POST: Certificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificacione = await _context.Certificaciones.FindAsync(id);
            if (certificacione != null)
            {
                _context.Certificaciones.Remove(certificacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificacioneExists(int id)
        {
            return _context.Certificaciones.Any(e => e.IdCert == id);
        }
    }
}
