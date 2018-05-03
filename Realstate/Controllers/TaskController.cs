using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Realstate.Data.Negocio;
using Realstate.Helpers;
using Realstate.Models;
using Realstate.Models.BaseDatos;
using Realstate.Models.Struct;

namespace Realstate.Controllers
{
    public class TaskController : Controller
    {



        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GeoRentingContext _context;
        private AreaProspeccionDAO _AreaProspeccionDAO;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public TaskController(GeoRentingContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _AreaProspeccionDAO = new AreaProspeccionDAO(context);
        }
        // GET: Task
        public async Task<IActionResult> Index(int IdArea, int idPredio)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {

                ViewData["IdPredio"] = IdArea.ToString();
                ViewBag.Propietario = new SelectList(_AreaProspeccionDAO.GetPropietario(), "Id", "Name");
                ViewBag.IdPredio_unique = idPredio.ToString();
                var _model = IdArea > 0 ? _AreaProspeccionDAO.ObtenePrediosCamposTab(IdArea) : null;
                return View(_model);
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPredio(String idPredio)
        {
            try
            {
                var model = _AreaProspeccionDAO.ObtenePredioId(int.Parse(idPredio));
                      var jsonModel = model;
                JSonConvertUtil.Convert(jsonModel);
                return Json(jsonModel);
            }
            catch (Exception e)
            {

                return null;
            }
        }
        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
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

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
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
    }
}