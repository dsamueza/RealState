using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realstate.Models.BaseDatos;

namespace Realstate.Controllers
{
    public class ZonaProspectadasController : Controller
    {
        private readonly GeoRentingContext _context;

        public ZonaProspectadasController(GeoRentingContext context)
        {
            _context = context;
        }

        // GET: ZonaProspectadas
        public async Task<IActionResult> Index()
        {
            var geoRentingContext = _context.ZonaProspectada.Where(x => x.StatusRegister != "E").Include(z => z.IdProyectoNavigation);
            return View(await geoRentingContext.ToListAsync());
        }


        public async Task<IActionResult> ZonaProyecto(int? idProject)
        {
            var geoRentingContext = _context.ZonaProspectada.Where(x => x.IdProyecto == idProject && x.StatusRegister != "E").Include(z => z.IdProyectoNavigation).Include(z => z.Predio);
            ViewBag.idProject = idProject;
            return PartialView(await geoRentingContext.ToListAsync());
        }
        public string ContarPredio(int? idzonaprospectada)
        {
            var zona = _context.ZonaProspectada.Where(x => x.Id == idzonaprospectada).FirstOrDefault();
            if (zona != null)
            {
                return zona.Predio.Count().ToString();
            }
            return "";
        }

        // GET: ZonaProspectadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaProspectada = await _context.ZonaProspectada
                .Include(z => z.IdProyectoNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (zonaProspectada == null)
            {
                return NotFound();
            }

            return View(zonaProspectada);
        }

        // GET: ZonaProspectadas/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.Project, "Id", "Name");
            return View();
        }

        // POST: ZonaProspectadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProyecto,Code,Name,StreetMain,StreetSecundary,Streetthree,Streetfour,Reference,Zona,Commentary,CreationDate,Usercreation,StatusRegister")] ZonaProspectada zonaProspectada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonaProspectada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Project, "Id", "Name", zonaProspectada.IdProyecto);
            return View(zonaProspectada);
        }

        // GET: ZonaProspectadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaProspectada = await _context.ZonaProspectada.SingleOrDefaultAsync(m => m.Id == id);
            if (zonaProspectada == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.Project, "Id", "Name", zonaProspectada.IdProyecto);
            return View(zonaProspectada);
        }

        // POST: ZonaProspectadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProyecto,Code,Name,StreetMain,StreetSecundary,Streetthree,Streetfour,Reference,Zona,Commentary,CreationDate,Usercreation,StatusRegister")] ZonaProspectada zonaProspectada)
        {
            if (id != zonaProspectada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonaProspectada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonaProspectadaExists(zonaProspectada.Id))
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
            ViewData["IdProyecto"] = new SelectList(_context.Project, "Id", "Name", zonaProspectada.IdProyecto);
            return View(zonaProspectada);
        }

        // GET: ZonaProspectadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonaProspectada = await _context.ZonaProspectada
                .Include(z => z.IdProyectoNavigation)
                .Include(z => z.Predio)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (zonaProspectada == null)
            {
                return NotFound();
            }

            return View(zonaProspectada);
        }

        // POST: ZonaProspectadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonaProspectada = await _context.ZonaProspectada.SingleOrDefaultAsync(m => m.Id == id);
            zonaProspectada.StatusRegister = "E";
            _context.ZonaProspectada.Update(zonaProspectada);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProyectosZona", "Projects", new { id = zonaProspectada.IdProyecto });
        }

        private bool ZonaProspectadaExists(int id)
        {
            return _context.ZonaProspectada.Any(e => e.Id == id);
        }
    }
}
