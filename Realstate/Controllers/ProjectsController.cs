﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realstate.Models.BaseDatos;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
            var geoRentingContext = _context.Project.Where(x => x.StatusRegister != "E").Include(p => p.IdAccountNavigation)
                .Include(p => p.IdContryNavigation)
                .Include(p => p.IdDistrictNavigation)
                .Include(p => p.IdLinkNavigation)
                .Include(p => p.IdParishNavigation)
                .Include(p => p.IdProvinceNavigation)
                .Include(p => p.IdSectorNavigation)
                .Include(p => p.Zona);
            return View(await geoRentingContext.ToListAsync());
        }
        public async Task<IActionResult> ProyectosZona(int? id)
        {
            var geoRentingContext = _context.Project.Include(p => p.IdAccountNavigation)
                .Include(p => p.IdContryNavigation)
                .Include(p => p.IdDistrictNavigation)
                .Include(p => p.IdLinkNavigation)
                .Include(p => p.IdParishNavigation)
                .Include(p => p.IdProvinceNavigation)
                .Include(p => p.IdSectorNavigation)
                .Include(p => p.Zona);
            ViewBag.id = id;
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
                .Include(p => p.IdContryNavigation)
                .Include(p => p.IdDistrictNavigation)
                .Include(p => p.IdLinkNavigation)
                .Include(p => p.IdParishNavigation)
                .Include(p => p.IdProvinceNavigation)
                .Include(p => p.IdSectorNavigation)
                .Include(p => p.Zona)
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
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Name");
            ViewData["IdContry"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["IdDistrict"] = new SelectList(_context.District, "Id", "Name");
            ViewData["IdLink"] = new SelectList(_context.Link, "Id", "Name");
            ViewData["IdParish"] = new SelectList(_context.Parish, "Id", "Name");
            ViewData["IdProvince"] = new SelectList(_context.Province, "Id", "Name");
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Name");
            ViewData["ZonaId"] = new SelectList(_context.Zona, "Id", "Name");
            return PartialView();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAccount,Code,Name,IdContry,IdProvince,IdDistrict,IdParish,IdSector,IdLink,ZonaId,Image,CreationDate,Usercreation,StatusRegister")] Project project, IFormFile upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var files = Request.Form.Files;
                    if (files.Count > 0)
                    {
                        var imagenarchivo = files[0];
                        var filePath = Path.GetTempFileName();

                        using (var stream = new MemoryStream())
                        {
                            await imagenarchivo.CopyToAsync(stream);
                            project.Image = stream.ToArray();
                        }
                    }
                    project.CreationDate = DateTime.Now;
                    project.StatusRegister = "A";
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Name", project.IdAccount);
                ViewData["IdContry"] = new SelectList(_context.Country, "Id", "Name", project.IdContry);
                ViewData["IdDistrict"] = new SelectList(_context.District, "Id", "Name", project.IdDistrict);
                ViewData["IdLink"] = new SelectList(_context.Link, "Id", "Name", project.IdLink);
                ViewData["IdParish"] = new SelectList(_context.Parish, "Id", "Name", project.IdParish);
                ViewData["IdProvince"] = new SelectList(_context.Province, "Id", "Name", project.IdProvince);
                ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Name", project.IdSector);
                ViewData["ZonaId"] = new SelectList(_context.Zona, "Id", "Name", project.ZonaId);
                return PartialView(project);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string GetImage(Int32 Id)
        {
            Project project = _context.Project.FirstOrDefault(c => c.Id == Id);
            if (project != null)
            {
                String s = "";
                string type = string.Empty;
                if (project.Image != null)
                {
                    s = Convert.ToBase64String(project.Image);
                }

                return "data:image/png;base64," + s.ToString();
            }
            else
            {
                return "";
            }
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
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Name", project.IdAccount);
            ViewData["IdContry"] = new SelectList(_context.Country, "Id", "Name", project.IdContry);
            ViewData["IdDistrict"] = new SelectList(_context.District, "Id", "Name", project.IdDistrict);
            ViewData["IdLink"] = new SelectList(_context.Link, "Id", "Name", project.IdLink);
            ViewData["IdParish"] = new SelectList(_context.Parish, "Id", "Name", project.IdParish);
            ViewData["IdProvince"] = new SelectList(_context.Province, "Id", "Name", project.IdProvince);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Name", project.IdSector);
            ViewData["ZonaId"] = new SelectList(_context.Zona, "Id", "Name", project.ZonaId);

            ViewBag.imagenactual = project.Image;

            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAccount,Code,Name,IdContry,IdProvince,IdDistrict,IdParish,IdSector,IdLink,ZonaId,CreationDate,Usercreation,StatusRegister")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var projectactual = _context.Project.Where(m => m.Id == id).FirstOrDefault();

                    var files = Request.Form.Files;
                    if (files.Count > 0)
                    {
                        var imagenarchivo = files[0];
                        var filePath = Path.GetTempFileName();

                        using (var stream = new MemoryStream())
                        {
                            await imagenarchivo.CopyToAsync(stream);
                            project.Image = stream.ToArray();
                            projectactual.Image = project.Image;
                        }
                    }
                    else
                    {
                        if (ViewBag.imagenactual != null)
                        {
                            project.Image = ViewBag.imagenactual;



                        }
                    }


                    projectactual.CreationDate = DateTime.Now;
                    projectactual.IdAccount = project.IdAccount;
                    projectactual.Name = project.Name;
                    projectactual.IdContry = project.IdContry;
                    projectactual.IdProvince = project.IdProvince;
                    projectactual.IdDistrict = project.IdDistrict;
                    projectactual.IdParish = project.IdParish;
                    projectactual.IdSector = project.IdSector;
                    projectactual.IdLink = project.IdLink;
                    projectactual.ZonaId = project.ZonaId;
                    projectactual.Usercreation = User.Identity.Name.ToString();
                    //projectactual.StatusRegister = project.StatusRegister;
                    _context.Update(projectactual);
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
            ViewData["IdAccount"] = new SelectList(_context.Account, "Id", "Name", project.IdAccount);
            ViewData["IdContry"] = new SelectList(_context.Country, "Id", "Name", project.IdContry);
            ViewData["IdDistrict"] = new SelectList(_context.District, "Id", "Name", project.IdDistrict);
            ViewData["IdLink"] = new SelectList(_context.Link, "Id", "Name", project.IdLink);
            ViewData["IdParish"] = new SelectList(_context.Parish, "Id", "Name", project.IdParish);
            ViewData["IdProvince"] = new SelectList(_context.Province, "Id", "Name", project.IdProvince);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Name", project.IdSector);
            ViewData["ZonaId"] = new SelectList(_context.Zona, "Id", "Name", project.ZonaId);
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
                .Include(p => p.IdContryNavigation)
                .Include(p => p.IdDistrictNavigation)
                .Include(p => p.IdLinkNavigation)
                .Include(p => p.IdParishNavigation)
                .Include(p => p.IdProvinceNavigation)
                .Include(p => p.IdSectorNavigation)
                .Include(p => p.Zona)
                .Include(p=>p.ZonaProspectada)
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
            project.StatusRegister = "E";
            _context.Project.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
