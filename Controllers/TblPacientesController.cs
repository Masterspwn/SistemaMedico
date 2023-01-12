using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentePreNat.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CentePreNat.Controllers
{
    public class TblPacientesController : Controller
    {
        private readonly centeadminContext _context;

        public TblPacientesController(centeadminContext context)
        {
            _context = context;
        }

        // GET: TblPacientes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblPacientes.ToListAsync());
        }

        // GET: TblPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblPacientes == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes
                .FirstOrDefaultAsync(m => m.PacHistorialClinico == id);
            if (tblPaciente == null)
            {
                return NotFound();
            }

            return View(tblPaciente);
        }

        // GET: TblPacientes/Create
        public IActionResult Create()
        {

            //var lastRecord = objContext.ResetPassword
            //               .Where(x
            //                     => x.Email == email
            //                     && x.Status == 0)
            //                 .OrderByDescending(x => x.Id)
            //                 .Take(1);
            return View();
        }

        // POST: TblPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacHistorialClinico,PacApellidos,PacGenero,PacEdad,PacFnacimiento,PacDireccion,PacTelefono,PacInstruccion,PacInstitucion,PacFinformacion,PacEmail,PacFentregainforme")] TblPaciente tblPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPaciente);
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPaciente);
        }

        // GET: TblPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblPacientes == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes.FindAsync(id);
            if (tblPaciente == null)
            {
                return NotFound();
            }
            return View(tblPaciente);
        }

        // POST: TblPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacHistorialClinico,PacApellidos,PacGenero,PacEdad,PacFnacimiento,PacDireccion,PacTelefono,PacInstruccion,PacInstitucion,PacFinformacion,PacEmail,PacFentregainforme")] TblPaciente tblPaciente)
        {
            if (id != tblPaciente.PacHistorialClinico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPacienteExists(tblPaciente.PacHistorialClinico))
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
            return View(tblPaciente);
        }

        // GET: TblPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblPacientes == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes
                .FirstOrDefaultAsync(m => m.PacHistorialClinico == id);
            if (tblPaciente == null)
            {
                return NotFound();
            }

            return View(tblPaciente);
        }

        // POST: TblPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblPacientes == null)
            {
                return Problem("Entity set 'centeadminContext.TblPacientes'  is null.");
            }
            var tblPaciente = await _context.TblPacientes.FindAsync(id);
            if (tblPaciente != null)
            {
                _context.TblPacientes.Remove(tblPaciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPacienteExists(int id)
        {
          return _context.TblPacientes.Any(e => e.PacHistorialClinico == id);
        }

        // GET: TblPacientes/Details/5
        public async Task<IActionResult> ProfilePaciente(int? id)
        {


            //var PacienteInfo = await _context.TblInfoprenatals
            //    .Join(_context.TblPacientes, info => info.PreHistorialClinico,
            //   pac => pac.PacHistorialClinico, (info, pac) => new { info, pac })
            //    .FirstOrDefaultAsync(x => x.info.PreIdInfo == id);

            //var PacienteInfo = await _context.TblPacientes
            //    .Join(_context.TblInfoprenatals, pac => pac.PacHistorialClinico,
            //    pre => pre.PreHistorialClinico, (pac,pre)=> new { pac,pre})
            //    .FirstOrDefaultAsync(x=> x.pac.PacHistorialClinico==id);

            //    .GroupJoin(_context.TblInfoprenatals, pac => pac.PacHistorialClinico,
            //    pre => pre.PreHistorialClinico, (pac, pre) => new { pac, pre })
            //    .FirstOrDefaultAsync(x => x.pac.PacHistorialClinico==id);

            //var PacienteInfo = await _context.TblPacientes
            //  .Join(_context.TblInfoprenatals, pac => pac.PacHistorialClinico, pre => pre.PreHistorialClinico, (pac, pre) => new { pac, pre })
            //   .ToListAsync();
            //var PacienteInfo = await _context.TblPacientes
            //    .Join(_context.TblInfoprenatals,pac => pac.PacHistorialClinico,pre => pre.PreHistorialClinico, (pac,pre)=> new { pac,pre} )
            //  .FirstOrDefaultAsync(m => m.pac.PacHistorialClinico == id);



            if (id == null || _context.TblPacientes == null)
            {
                return NotFound();
            }

            var tblPaciente = await _context.TblPacientes
               .FirstOrDefaultAsync(m => m.PacHistorialClinico == id)
                ;
            ViewData["Pacienteid"] = tblPaciente.PacHistorialClinico;
           

            if (tblPaciente == null)
            {
                return NotFound();
            }

            return View(tblPaciente);
        }
        public IActionResult GetIfoPrenat(int? id)
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

            ViewData["PacId"] = id;
            ViewData["prenat"] = centeadminContext;
            return View(centeadminContext);
        }

    }
}
