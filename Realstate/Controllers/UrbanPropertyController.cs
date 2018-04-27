using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Realstate.Models.BaseDatos;
using Realstate.Data.Negocio;
using Microsoft.AspNetCore.Identity;
using Realstate.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Realstate.Controllers
{
    public class UrbanPropertyController : Controller
    {
        // GET: UrbanProperty

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GeoRentingContext _context;
        private AreaProspeccionDAO _AreaProspeccionDAO;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UrbanPropertyController(GeoRentingContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _AreaProspeccionDAO = new AreaProspeccionDAO(context);
        }

        public ActionResult Index()
        {
            return View();
        }



        // GET: UrbanProperty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrbanProperty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UrbanProperty/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrbanProperty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UrbanProperty/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrbanProperty/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public async Task<IActionResult> AreasProspeccion( int IdProyecto, int IdArea=0)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                _AreaProspeccionDAO.ObtenerNombreProyecto(IdProyecto);
                ViewBag.NombreProyecto = _AreaProspeccionDAO.ObtenerNombreProyecto(IdProyecto);
                ViewData["IdPredio"] = IdArea.ToString();
                return View();
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AreasProspeccion(ZonaProspectada Model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {


                    Model.CreationDate = DateTime.Now;
                    Model.Usercreation = user.UserName;
                    _AreaProspeccionDAO.GuardarAreas_Prospeccion(Model);
                    ViewData["IdPredio"] = Model.Id.ToString();
                }

                return View(Model);
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");

        }
    }
}