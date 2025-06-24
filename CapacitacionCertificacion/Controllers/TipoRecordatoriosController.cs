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
    public class TipoRecordatoriosController : Controller
    {
        private readonly CapacitacionCertificacionContext _context;

        public TipoRecordatoriosController(CapacitacionCertificacionContext context)
        {
            _context = context;
        }

        // GET: TipoRecordatorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoRecordatorios.ToListAsync());
        }

        // GET: TipoRecordatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRecordatorio = await _context.TipoRecordatorios
                .FirstOrDefaultAsync(m => m.IdTipoRecord == id);
            if (tipoRecordatorio == null)
            {
                return NotFound();
            }

            return View(tipoRecordatorio);
        }

        // GET: TipoRecordatorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRecordatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoRecord,DescripcionTipo")] TipoRecordatorio tipoRecordatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRecordatorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRecordatorio);
        }

        // GET: TipoRecordatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRecordatorio = await _context.TipoRecordatorios.FindAsync(id);
            if (tipoRecordatorio == null)
            {
                return NotFound();
            }
            return View(tipoRecordatorio);
        }

        // POST: TipoRecordatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoRecord,DescripcionTipo")] TipoRecordatorio tipoRecordatorio)
        {
            if (id != tipoRecordatorio.IdTipoRecord)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRecordatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRecordatorioExists(tipoRecordatorio.IdTipoRecord))
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
            return View(tipoRecordatorio);
        }

        // GET: TipoRecordatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRecordatorio = await _context.TipoRecordatorios
                .FirstOrDefaultAsync(m => m.IdTipoRecord == id);
            if (tipoRecordatorio == null)
            {
                return NotFound();
            }

            return View(tipoRecordatorio);
        }

        // POST: TipoRecordatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoRecordatorio = await _context.TipoRecordatorios.FindAsync(id);
            if (tipoRecordatorio != null)
            {
                _context.TipoRecordatorios.Remove(tipoRecordatorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRecordatorioExists(int id)
        {
            return _context.TipoRecordatorios.Any(e => e.IdTipoRecord == id);
        }
    }
}
