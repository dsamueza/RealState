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
    public class ProjectsController : Controller
    {
        private readonly GeoRentingContext _context;

        public ProjectsController(GeoRentingContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var geoRentingContext = _context.Project.Include(p => p.IdAccountNavigation).Include(p => p.IdTypeProjectNavigation).Include(p => p.IdZonaNavigation);
            return View(await geoRentingContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.IdAccountNavigation)
                .Include(p => p.IdTypeProjectNavigation)
                .Include(p => p.IdZonaNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Code");
            ViewData["IdTypeProject"] = new SelectList(_context.TypeProject, "Id", "Code");
            ViewData["IdZona"] = new SelectList(_context.Zona, "Id", "Id");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAccount,Code,Name,IdZona,CreationDate,IdTypeProject,StatusRegister")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Code", project.IdAccount);
            ViewData["IdTypeProject"] = new SelectList(_context.TypeProject, "Id", "Code", project.IdTypeProject);
            ViewData["IdZona"] = new SelectList(_context.Zona, "Id", "Id", project.IdZona);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Code", project.IdAccount);
            ViewData["IdTypeProject"] = new SelectList(_context.TypeProject, "Id", "Code", project.IdTypeProject);
            ViewData["IdZona"] = new SelectList(_context.Zona, "Id", "Id", project.IdZona);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAccount,Code,Name,IdZona,CreationDate,IdTypeProject,StatusRegister")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Code", project.IdAccount);
            ViewData["IdTypeProject"] = new SelectList(_context.TypeProject, "Id", "Code", project.IdTypeProject);
            ViewData["IdZona"] = new SelectList(_context.Zona, "Id", "Id", project.IdZona);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.IdAccountNavigation)
                .Include(p => p.IdTypeProjectNavigation)
                .Include(p => p.IdZonaNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
