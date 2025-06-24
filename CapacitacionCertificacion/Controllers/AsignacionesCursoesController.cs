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
    public class AsignacionesCursoesController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public AsignacionesCursoesController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: AsignacionesCursoes
        public async Task<IActionResult> Index()
        {
            var capacitacionCertificacionContext = _context.AsignacionesCursos.Include(a => a.IdCursoNavigation).Include(a => a.IdEmpNavigation);
            return View(await capacitacionCertificacionContext.ToListAsync());
        }

        // GET: AsignacionesCursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionesCurso = await _context.AsignacionesCursos
                .Include(a => a.IdCursoNavigation)
                .Include(a => a.IdEmpNavigation)
                .FirstOrDefaultAsync(m => m.IdAsign == id);
            if (asignacionesCurso == null)
            {
                return NotFound();
            }

            return View(asignacionesCurso);
        }

        // GET: AsignacionesCursoes/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso");
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "NombreEmp");
            return View();
        }

        // POST: AsignacionesCursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsign,IdEmp,IdCurso,FechaAsign,Estado,FechaFinalizacion")] AsignacionesCurso asignacionesCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionesCurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso", asignacionesCurso.IdCurso);
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "NombreEmp", asignacionesCurso.IdEmp);
            return View(asignacionesCurso);
        }

        // GET: AsignacionesCursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionesCurso = await _context.AsignacionesCursos.FindAsync(id);
            if (asignacionesCurso == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso", asignacionesCurso.IdCurso);
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "NombreEmp", asignacionesCurso.IdEmp);
            return View(asignacionesCurso);
        }

        // POST: AsignacionesCursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsign,IdEmp,IdCurso,FechaAsign,Estado,FechaFinalizacion")] AsignacionesCurso asignacionesCurso)
        {
            if (id != asignacionesCurso.IdAsign)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionesCurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionesCursoExists(asignacionesCurso.IdAsign))
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
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "IdCurso", "NombreCurso", asignacionesCurso.IdCurso);
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "NombreEmp", asignacionesCurso.IdEmp);
            return View(asignacionesCurso);
        }

        // GET: AsignacionesCursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionesCurso = await _context.AsignacionesCursos
                .Include(a => a.IdCursoNavigation)
                .Include(a => a.IdEmpNavigation)
                .FirstOrDefaultAsync(m => m.IdAsign == id);
            if (asignacionesCurso == null)
            {
                return NotFound();
            }

            return View(asignacionesCurso);
        }

        // POST: AsignacionesCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacionesCurso = await _context.AsignacionesCursos.FindAsync(id);
            if (asignacionesCurso != null)
            {
                _context.AsignacionesCursos.Remove(asignacionesCurso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionesCursoExists(int id)
        {
            return _context.AsignacionesCursos.Any(e => e.IdAsign == id);
        }
    }
}
