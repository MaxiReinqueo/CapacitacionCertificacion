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
    public class InformesCumplimientoController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public InformesCumplimientoController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: InformesCumplimiento
        public async Task<IActionResult> Index()
        {
            var capacitacionCertificacionContext = _context.InformesCumplimientos.Include(i => i.IdEmpNavigation).Include(i => i.IdTipoInformeNavigation);
            return View(await capacitacionCertificacionContext.ToListAsync());
        }

        // GET: InformesCumplimiento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informesCumplimiento = await _context.InformesCumplimientos
                .Include(i => i.IdEmpNavigation)
                .Include(i => i.IdTipoInformeNavigation)
                .FirstOrDefaultAsync(m => m.IdInfor == id);
            if (informesCumplimiento == null)
            {
                return NotFound();
            }

            return View(informesCumplimiento);
        }

        // GET: InformesCumplimiento/Create
        public IActionResult Create()
        {
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp");
            ViewData["IdTipoInforme"] = new SelectList(_context.TipoInformes, "IdTipoInforme", "IdTipoInforme");
            return View();
        }

        // POST: InformesCumplimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInfor,IdTipoInforme,IdEmp,DescripcionInfor,FechaEmision")] InformesCumplimiento informesCumplimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informesCumplimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp", informesCumplimiento.IdEmp);
            ViewData["IdTipoInforme"] = new SelectList(_context.TipoInformes, "IdTipoInforme", "IdTipoInforme", informesCumplimiento.IdTipoInforme);
            return View(informesCumplimiento);
        }

        // GET: InformesCumplimiento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informesCumplimiento = await _context.InformesCumplimientos.FindAsync(id);
            if (informesCumplimiento == null)
            {
                return NotFound();
            }
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp", informesCumplimiento.IdEmp);
            ViewData["IdTipoInforme"] = new SelectList(_context.TipoInformes, "IdTipoInforme", "IdTipoInforme", informesCumplimiento.IdTipoInforme);
            return View(informesCumplimiento);
        }

        // POST: InformesCumplimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInfor,IdTipoInforme,IdEmp,DescripcionInfor,FechaEmision")] InformesCumplimiento informesCumplimiento)
        {
            if (id != informesCumplimiento.IdInfor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informesCumplimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformesCumplimientoExists(informesCumplimiento.IdInfor))
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
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp", informesCumplimiento.IdEmp);
            ViewData["IdTipoInforme"] = new SelectList(_context.TipoInformes, "IdTipoInforme", "IdTipoInforme", informesCumplimiento.IdTipoInforme);
            return View(informesCumplimiento);
        }

        // GET: InformesCumplimiento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informesCumplimiento = await _context.InformesCumplimientos
                .Include(i => i.IdEmpNavigation)
                .Include(i => i.IdTipoInformeNavigation)
                .FirstOrDefaultAsync(m => m.IdInfor == id);
            if (informesCumplimiento == null)
            {
                return NotFound();
            }

            return View(informesCumplimiento);
        }

        // POST: InformesCumplimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var informesCumplimiento = await _context.InformesCumplimientos.FindAsync(id);
            if (informesCumplimiento != null)
            {
                _context.InformesCumplimientos.Remove(informesCumplimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformesCumplimientoExists(int id)
        {
            return _context.InformesCumplimientos.Any(e => e.IdInfor == id);
        }
    }
}
