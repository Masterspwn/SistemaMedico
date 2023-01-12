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
    public class TblDinamicafamiliarsController : Controller
    {
        private readonly centeadminContext _context;

        public TblDinamicafamiliarsController(centeadminContext context)
        {
            _context = context;
        }

        // GET: TblDinamicafamiliars
        public async Task<IActionResult> Index()
        {
            var centeadminContext = _context.TblDinamicafamiliars.Include(t => t.DimHistorialClinicoNavigation);
            return View(await centeadminContext.ToListAsync());
        }

        // GET: TblDinamicafamiliars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblDinamicafamiliars == null)
            {
                return NotFound();
            }

            var tblDinamicafamiliar = await _context.TblDinamicafamiliars
                .Include(t => t.DimHistorialClinicoNavigation)
                .FirstOrDefaultAsync(m => m.DimIdTipoFamilia == id);
            if (tblDinamicafamiliar == null)
            {
                return NotFound();
            }

            return View(tblDinamicafamiliar);
        }

        // GET: TblDinamicafamiliars/Create
        public IActionResult Create()
        {
            ViewData["DimHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico");
            return View();
        }

        // POST: TblDinamicafamiliars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimHistorialClinico,DimIdTipoFamilia,DimTipoFamilia")] TblDinamicafamiliar tblDinamicafamiliar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDinamicafamiliar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DimHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblDinamicafamiliar.DimHistorialClinico);
            return View(tblDinamicafamiliar);
        }

        // GET: TblDinamicafamiliars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblDinamicafamiliars == null)
            {
                return NotFound();
            }

            var tblDinamicafamiliar = await _context.TblDinamicafamiliars.FindAsync(id);
            if (tblDinamicafamiliar == null)
            {
                return NotFound();
            }
            ViewData["DimHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblDinamicafamiliar.DimHistorialClinico);
            return View(tblDinamicafamiliar);
        }

        // POST: TblDinamicafamiliars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimHistorialClinico,DimIdTipoFamilia,DimTipoFamilia")] TblDinamicafamiliar tblDinamicafamiliar)
        {
            if (id != tblDinamicafamiliar.DimIdTipoFamilia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDinamicafamiliar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDinamicafamiliarExists(tblDinamicafamiliar.DimIdTipoFamilia))
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
            ViewData["DimHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblDinamicafamiliar.DimHistorialClinico);
            return View(tblDinamicafamiliar);
        }

        // GET: TblDinamicafamiliars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblDinamicafamiliars == null)
            {
                return NotFound();
            }

            var tblDinamicafamiliar = await _context.TblDinamicafamiliars
                .Include(t => t.DimHistorialClinicoNavigation)
                .FirstOrDefaultAsync(m => m.DimIdTipoFamilia == id);
            if (tblDinamicafamiliar == null)
            {
                return NotFound();
            }

            return View(tblDinamicafamiliar);
        }

        // POST: TblDinamicafamiliars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblDinamicafamiliars == null)
            {
                return Problem("Entity set 'centeadminContext.TblDinamicafamiliars'  is null.");
            }
            var tblDinamicafamiliar = await _context.TblDinamicafamiliars.FindAsync(id);
            if (tblDinamicafamiliar != null)
            {
                _context.TblDinamicafamiliars.Remove(tblDinamicafamiliar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDinamicafamiliarExists(int id)
        {
          return _context.TblDinamicafamiliars.Any(e => e.DimIdTipoFamilia == id);
        }
    }
}
