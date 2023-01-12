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
    public class TblInfoprenatalsController : Controller
    {
        private readonly centeadminContext _context;

        public TblInfoprenatalsController(centeadminContext context)
        {
            _context = context;
        }

        // GET: TblInfoprenatals
        public async Task<IActionResult> Index( int? id)
        {
            var centeadminContext = _context.TblInfoprenatals.Include(t => t.PreHistorialClinicoNavigation)
                ;
            return View(await centeadminContext.ToListAsync());
        }


        // GET: TblInfoprenatals for id
        public IActionResult Index2(int? id)
        {
            var centeadminContext = from pre in _context.TblInfoprenatals
                                    where pre.PreHistorialClinico == id
                                    //join pac in _context.TblPacientes
                                    //  on pre.PreIdInfo equals id
                                    select new TblInfoprenatal
                                    {
                                        PreHistorialClinico = pre.PreHistorialClinico,
                                        PreIdInfo = pre.PreIdInfo,
                                        PreNumeroEmbarazo = pre.PreNumeroEmbarazo,
                                        PreEstadoEmocional = pre.PreEstadoEmocional,
                                        PreSaludMental = pre.PreSaludMental,
                                        PreComplicaciones = pre.PreComplicaciones,
                                        PrePlanificacion = pre.PrePlanificacion,
                                        PreAborto = pre.PreAborto,
                                        PreMotivo = pre.PreMotivo,
                                        PreHistorialClinicoNavigation = pre.PreHistorialClinicoNavigation
                                    };

            ViewData["PacId"]= id;
            return View(centeadminContext);
        }


        // GET: TblInfoprenatals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblInfoprenatals == null)
            {
                return NotFound();
            }

            var tblInfoprenatal = await _context.TblInfoprenatals
                .Include(t => t.PreHistorialClinicoNavigation)
                .FirstOrDefaultAsync(m => m.PreIdInfo == id);
            if (tblInfoprenatal == null)
            {
                return NotFound();
            }

            return View(tblInfoprenatal);
        }

        // GET: TblInfoprenatals/Create
        public IActionResult Create(int id)
        {
            //ViewData["PreHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico");
            ViewData["PreHistorialClinico"] = id;
           
            return View();
        }

        // POST: TblInfoprenatals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreHistorialClinico,PreIdInfo,PreNumeroEmbarazo,PreEstadoEmocional,PreSaludMental,PreComplicaciones,PrePlanificacion,PreAborto,PreMotivo")] TblInfoprenatal tblInfoprenatal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblInfoprenatal);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PreHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblInfoprenatal.PreHistorialClinico);
            return View(tblInfoprenatal);
        }

        // GET: TblInfoprenatals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblInfoprenatals == null)
            {
                return NotFound();
            }

            var tblInfoprenatal = await _context.TblInfoprenatals.FindAsync(id);
            if (tblInfoprenatal == null)
            {
                return NotFound();
            }
            ViewData["PreHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblInfoprenatal.PreHistorialClinico);
            return View(tblInfoprenatal);
        }

        // POST: TblInfoprenatals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreHistorialClinico,PreIdInfo,PreNumeroEmbarazo,PreEstadoEmocional,PreSaludMental,PreComplicaciones,PrePlanificacion,PreAborto,PreMotivo")] TblInfoprenatal tblInfoprenatal)
        {
            if (id != tblInfoprenatal.PreIdInfo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblInfoprenatal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblInfoprenatalExists(tblInfoprenatal.PreIdInfo))
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
            ViewData["PreHistorialClinico"] = new SelectList(_context.TblPacientes, "PacHistorialClinico", "PacHistorialClinico", tblInfoprenatal.PreHistorialClinico);
            return View(tblInfoprenatal);
        }

        // GET: TblInfoprenatals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblInfoprenatals == null)
            {
                return NotFound();
            }

            var tblInfoprenatal = await _context.TblInfoprenatals
                .Include(t => t.PreHistorialClinicoNavigation)
                .FirstOrDefaultAsync(m => m.PreIdInfo == id);
            if (tblInfoprenatal == null)
            {
                return NotFound();
            }

            return View(tblInfoprenatal);
        }

        // POST: TblInfoprenatals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblInfoprenatals == null)
            {
                return Problem("Entity set 'centeadminContext.TblInfoprenatals'  is null.");
            }
            var tblInfoprenatal = await _context.TblInfoprenatals.FindAsync(id);
            if (tblInfoprenatal != null)
            {
                _context.TblInfoprenatals.Remove(tblInfoprenatal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblInfoprenatalExists(int id)
        {
          return _context.TblInfoprenatals.Any(e => e.PreIdInfo == id);
        }

    }
}
