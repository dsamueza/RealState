using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Realstate.Data.Negocio;
using Realstate.Helpers;
using Realstate.Models;
using Realstate.Models.BaseDatos;
using Realstate.Models.Struct;
using System.Configuration;
namespace Realstate.Controllers
{
    public class TaskController : Controller
    {



        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GeoRentingContext _context;
        private AreaProspeccionDAO _AreaProspeccionDAO;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private Correos _correo = new Correos();

        private IHostingEnvironment _Env;
        public TaskController(GeoRentingContext context,
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager
            , IHostingEnvironment envrnmt)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _AreaProspeccionDAO = new AreaProspeccionDAO(context);
            _Env = envrnmt;
        }
        // GET: Task
        public async Task<IActionResult> Index(int IdArea, int idPredio)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                
                ViewData["Idareas"] = IdArea.ToString();
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
        [HttpPost]
    
        public async Task<JsonResult> _Note(String coment , String Idpredio )
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {

                  var id=  _AreaProspeccionDAO.GuardarAreas_task(coment, int.Parse(Idpredio), "", "", 1, "", user.UserName, "");

                  var model=  _AreaProspeccionDAO.ObtenerTareasbyId(id);
                    //   _correo.enviar();
                    JSonConvertUtil.Convert(model);
                    return Json(model);
                }
                return Json("");
            }
            return Json("");
        }
        [HttpPost]

        public async Task<JsonResult>  _Message (String coment , String subject , String des, String Idpredio,String urlpath)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {

                    var id = _AreaProspeccionDAO.GuardarAreas_task(coment, int.Parse(Idpredio), des, subject, 2, urlpath, user.UserName,"");
                    var model = _AreaProspeccionDAO.ObtenerTareasbyId(id);
                      _correo.enviar(subject,des,coment, urlpath);
                    JSonConvertUtil.Convert(model);
                    return Json(model);
                }
                return Json("");
            }
            return Json("");
        }
        [HttpPost]

        public async Task<JsonResult> _interaction(String coment, String subject, String reunion, String Idpredio, String destinatario, String type)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {

                    var id = _AreaProspeccionDAO.GuardarAreas_task(coment, int.Parse(Idpredio), destinatario, subject, int.Parse(type),"", user.UserName, reunion);
                    var model = _AreaProspeccionDAO.ObtenerTareasbyId(id);
                    JSonConvertUtil.Convert(model);
                    return Json(model);
                }
              
                return Json("");
            }
   
            return Json("");
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

        [HttpGet]
        public JsonResult GetDetailTask(String idPredio)
        {
            try
            {
                var model = _AreaProspeccionDAO.ObtenerTareas(int.Parse(idPredio));
                if (model.Count() > 0)
                {
           
                    JSonConvertUtil.Convert(model);

                    return Json(model);
                }
           
                return Json("-1");
            }
            catch (Exception e)
            {
                var model = _AreaProspeccionDAO.ObtenerTareasini(5);
                return Json(model);
            }
        }
        #region Carga de archivos
        [HttpPost]
       
        public JsonResult UploadTask(IFormFile fileBranch)
        {
            //var r = new List<UploadFilesResult>();

            //foreach (string file in Request.Files)
            //{
            //    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
            //    if (hpf.ContentLength == 0)
            //        continue;

            //    string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
            //    hpf.SaveAs(savedFileName); // Save the file

            //    r.Add(new ViewDataUploadFilesResult()
            //    {
            //        Name = hpf.FileName,
            //        Length = hpf.ContentLength,
            //        Type = hpf.ContentType
            //    });
            //}
            return Json("");
        }

        #endregion
        [HttpPost]
        public ActionResult UploadFiles()
        {
            DateTime localDate = DateTime.Now;
            // Checking no of files injected in Request object  
            string LogFile = localDate.ToString("yyyyMMddHHmmss");
            var Filepath = "";
            //    bool exitdirectorio = false;
            foreach (var item in Request.Form.Files)
            {
                var file = item;
                string fileName = file.FileName;
                 Filepath = _Env.WebRootPath + "\\Document\\ " + LogFile + "_" + file.FileName.ToString();
                if (file.Length== 0)
                    continue;
                if (file.Length > 0)
                {

                    using (var fileStream = new FileStream(Filepath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                }
            return Json(Filepath);
        }
           
        }

    }


  
