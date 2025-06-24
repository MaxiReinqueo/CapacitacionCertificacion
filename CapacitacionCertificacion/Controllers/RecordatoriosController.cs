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
    public class RecordatoriosController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public RecordatoriosController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: Recordatorios
        public async Task<IActionResult> Index()
        {
            var capacitacionCertificacionContext = _context.Recordatorios.Include(r => r.IdEmpNavigation).Include(r => r.IdTipoRecordNavigation);
            return View(await capacitacionCertificacionContext.ToListAsync());
        }

        // GET: Recordatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordatorio = await _context.Recordatorios
                .Include(r => r.IdEmpNavigation)
                .Include(r => r.IdTipoRecordNavigation)
                .FirstOrDefaultAsync(m => m.IdRecord == id);
            if (recordatorio == null)
            {
                return NotFound();
            }

            return View(recordatorio);
        }

        // GET: Recordatorios/Create
        public IActionResult Create()
        {
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp");
            ViewData["IdTipoRecord"] = new SelectList(_context.TipoRecordatorios, "IdTipoRecord", "IdTipoRecord");
            return View();
        }

        // POST: Recordatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecord,IdEmp,IdTipoRecord,FechaEjecucion,MensajeRecord")] Recordatorio recordatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recordatorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp", recordatorio.IdEmp);
            ViewData["IdTipoRecord"] = new SelectList(_context.TipoRecordatorios, "IdTipoRecord", "IdTipoRecord", recordatorio.IdTipoRecord);
            return View(recordatorio);
        }

        // GET: Recordatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordatorio = await _context.Recordatorios.FindAsync(id);
            if (recordatorio == null)
            {
                return NotFound();
            }
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp", recordatorio.IdEmp);
            ViewData["IdTipoRecord"] = new SelectList(_context.TipoRecordatorios, "IdTipoRecord", "IdTipoRecord", recordatorio.IdTipoRecord);
            return View(recordatorio);
        }

        // POST: Recordatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecord,IdEmp,IdTipoRecord,FechaEjecucion,MensajeRecord")] Recordatorio recordatorio)
        {
            if (id != recordatorio.IdRecord)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordatorioExists(recordatorio.IdRecord))
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
            ViewData["IdEmp"] = new SelectList(_context.Empleados, "IdEmp", "IdEmp", recordatorio.IdEmp);
            ViewData["IdTipoRecord"] = new SelectList(_context.TipoRecordatorios, "IdTipoRecord", "IdTipoRecord", recordatorio.IdTipoRecord);
            return View(recordatorio);
        }

        // GET: Recordatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordatorio = await _context.Recordatorios
                .Include(r => r.IdEmpNavigation)
                .Include(r => r.IdTipoRecordNavigation)
                .FirstOrDefaultAsync(m => m.IdRecord == id);
            if (recordatorio == null)
            {
                return NotFound();
            }

            return View(recordatorio);
        }

        // POST: Recordatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordatorio = await _context.Recordatorios.FindAsync(id);
            if (recordatorio != null)
            {
                _context.Recordatorios.Remove(recordatorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordatorioExists(int id)
        {
            return _context.Recordatorios.Any(e => e.IdRecord == id);
        }
    }
}
