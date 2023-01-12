using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentePreNat.Models;

namespace CentePreNat.Controllers
{
    public class TblFamiliaresController : Controller
    {
        private readonly centeadminContext _context;

        public TblFamiliaresController(centeadminContext context)
        {
            _context = context;
        }

        // GET: TblFamiliares
        public async Task<IActionResult> Index()
        {
            var centeadminContext = _context.TblFamiliares.Include(t => t.FamHistorialClinicoNavigation);
            return View(await centeadminContext.ToListAsync());
        }

        // GET: TblFamiliares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblFamiliares == null)
            {
                return NotFound();
            }

            var tblFamiliare = await _context.TblFamiliares
                .Include(t => t.FamHistorialClinicoNavigation)
                .FirstOrDefaultAsync(m => m.FamIdFamiliar == id);
            if (tblFamiliare == null)
            {
                return NotFound();
            }

            return View(tblFamiliare);
        }

        // GET: TblFamiliares/Create
        public IActionResult Create()
        {
            ViewData["FamHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico");
            return View();
        }

        // POST: TblFamiliares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FamHistorialClinico,FamIdFamiliar,FamParentesco,FamNombre,FamEdad,FamProfesion,FamObservacion")] TblFamiliare tblFamiliare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFamiliare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FamHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblFamiliare.FamHistorialClinico);
            return View(tblFamiliare);
        }

        // GET: TblFamiliares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblFamiliares == null)
            {
                return NotFound();
            }

            var tblFamiliare = await _context.TblFamiliares.FindAsync(id);
            if (tblFamiliare == null)
            {
                return NotFound();
            }
            ViewData["FamHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblFamiliare.FamHistorialClinico);
            return View(tblFamiliare);
        }

        // POST: TblFamiliares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FamHistorialClinico,FamIdFamiliar,FamParentesco,FamNombre,FamEdad,FamProfesion,FamObservacion")] TblFamiliare tblFamiliare)
        {
            if (id != tblFamiliare.FamIdFamiliar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFamiliare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFamiliareExists(tblFamiliare.FamIdFamiliar))
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
            ViewData["FamHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblFamiliare.FamHistorialClinico);
            return View(tblFamiliare);
        }

        // GET: TblFamiliares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblFamiliares == null)
            {
                return NotFound();
            }

            var tblFamiliare = await _context.TblFamiliares
                .Include(t => t.FamHistorialClinicoNavigation)
                .FirstOrDefaultAsync(m => m.FamIdFamiliar == id);
            if (tblFamiliare == null)
            {
                return NotFound();
            }

            return View(tblFamiliare);
        }

        // POST: TblFamiliares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblFamiliares == null)
            {
                return Problem("Entity set 'centeadminContext.TblFamiliares'  is null.");
            }
            var tblFamiliare = await _context.TblFamiliares.FindAsync(id);
            if (tblFamiliare != null)
            {
                _context.TblFamiliares.Remove(tblFamiliare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFamiliareExists(int id)
        {
          return _context.TblFamiliares.Any(e => e.FamIdFamiliar == id);
        }
    }
}
