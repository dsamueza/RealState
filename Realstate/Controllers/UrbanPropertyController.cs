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
using Newtonsoft.Json;
using Realstate.Helpers;
using Realstate.Models.Struct;
using Microsoft.AspNetCore.Mvc.Rendering;

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




        public async Task<IActionResult> AreasProspeccion( int IdProyecto, int IdArea)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
             
                ViewBag.NombreProyecto = _AreaProspeccionDAO.ObtenerNombreProyecto(IdProyecto);
                ViewData["IdPredio"] = IdArea.ToString();
                ViewBag.Propietario = new SelectList(_AreaProspeccionDAO.GetPropietario(), "Id", "Name");
                ZonaProspectada _model = IdArea > 0 ?  _AreaProspeccionDAO.ObteneZonaProspectada(IdArea) : new ZonaProspectada();
                return View(_model);
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
                ViewBag.Propietario = new SelectList(_AreaProspeccionDAO.GetPropietario(), "Id", "Name");
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

        [HttpPost]
        public async Task<JsonResult> GuardarPredios(String ModelJson, String IdArea) {
            var user = await _userManager.GetUserAsync(User);
            var _model = JSonConvertUtil.Deserialize<List<PredioViewModel>>(ModelJson);
            _AreaProspeccionDAO.GuardarPredidios(_model, user.UserName,int.Parse(IdArea));
            return Json("");
        }
        [HttpPost]
        public async Task<JsonResult> deletePredios(String IdPredio)
        {
            var user = await _userManager.GetUserAsync(User);

         var variable=   _AreaProspeccionDAO.deletePredidios(int.Parse(IdPredio));
            return Json(variable);
        }

        [HttpGet]
        public JsonResult GetGetPredio(String idPredio)
        {
            try
            {
                var model = _AreaProspeccionDAO.ObtenePredios(int.Parse(idPredio));
                IList<PredioViewModel> _empyModel = new List<PredioViewModel>();
                  _empyModel.Add(EntyPredio());
               var jsonModel = model!=null ? model : _empyModel;
                JSonConvertUtil.Convert(jsonModel);
                return Json(jsonModel);
            }
            catch (Exception e)
            {
                
                return null;
            }
        }
        public PredioViewModel EntyPredio() {
            PredioViewModel _predio = new PredioViewModel();
            _predio.IdProyecto = 0;
            _predio.IdZonaProspectada = 0;
            _predio.Secuencial = 0;
            _predio.IdPropietario = 0;
            _predio.Name = "";
            _predio.Zona = "";
            _predio.Value = "";
            _predio.Latitude = "";
            _predio.Length = "";
            _predio.StatusRegister = "D";
            _predio.Image = "";
            _predio.Id = 0;
            _predio.Coordenas = "-9LG";

            return _predio;

        }


    }
}