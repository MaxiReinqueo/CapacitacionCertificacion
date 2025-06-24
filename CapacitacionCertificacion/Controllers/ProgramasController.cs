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
    public class ProgramasController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public ProgramasController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: Programas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programas.ToListAsync());
        }

        // GET: Programas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas
                .FirstOrDefaultAsync(m => m.IdPg == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // GET: Programas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPg,NombrePg,DescripcionPg,FechaInicioPg,FechaFinPg")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        // GET: Programas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas.FindAsync(id);
            if (programa == null)
            {
                return NotFound();
            }
            return View(programa);
        }

        // POST: Programas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPg,NombrePg,DescripcionPg,FechaInicioPg,FechaFinPg")] Programa programa)
        {
            if (id != programa.IdPg)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaExists(programa.IdPg))
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
            return View(programa);
        }

        // GET: Programas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programa = await _context.Programas
                .FirstOrDefaultAsync(m => m.IdPg == id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // POST: Programas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programa = await _context.Programas.FindAsync(id);
            if (programa != null)
            {
                _context.Programas.Remove(programa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaExists(int id)
        {
            return _context.Programas.Any(e => e.IdPg == id);
        }
    }
}
