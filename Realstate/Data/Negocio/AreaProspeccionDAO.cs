using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realstate.Models.BaseDatos;
using Realstate.Models.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realstate.Data.Negocio
{
    public class AreaProspeccionDAO
    {
        private readonly GeoRentingContext _context;

        public AreaProspeccionDAO(GeoRentingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene el nombre de proyecto 
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Nombre unico por proyecto</returns>
        public string ObtenerNombreProyecto(int id) {

            var area = _context.ZonaProspectada.Where(x => x.Id.Equals(id)).Select(x =>x.IdProyecto);
            if (area.Count() > 0) {
                var project = _context.Project.Where(x => x.Id.Equals(area.First())).First().Name;
                return project;
            }
   
            return "";
        }

        /// <summary>
        /// Guardar Datos del Modelo
        /// </summary>
        /// <param name="_model">Datos de la tabla zonaprospecta</param>
        /// <returns> El resultado de la base de datos</returns>

        public int GuardarAreas_Prospeccion(ZonaProspectada _model) {


        
            _context.Add(_model);
            _context.Entry(_model).State = _model.Id > 0 ? EntityState.Modified : EntityState.Added;
            var get= _context.SaveChanges();
            return get;
        }
        /// <summary>
        /// Guardar Predios enviados en listas
        /// </summary>
        /// <param name="_model ">Contiene los datos en lista de predios enviados desde el model VUE.JS</param>
        /// <returns></returns>
        public int GuardarPredidios(List<PredioViewModel> _model, String user ,int AreaProspeccion)
        {

            int get = 0;
            try
            {
                foreach (var item in _model)
                {
                    Predio _predio = new Predio();
                    _predio.Id = item.Id;
                    _predio.CreationDate = DateTime.Now;
                    _predio.IdPropietario = item.IdPropietario;
                    _predio.IdZonaProspectada = AreaProspeccion;
                    _predio.Latitude = item.Latitude;
                    _predio.Length = item.Length;
                    _predio.Name = item.Name;
                    _predio.StatusRegister = item.StatusRegister;
                    _predio.Usercreation = user;
                    _predio.Value = item.Value;
                    _predio.Zona = item.Zona;
                    _predio.Image =  item.Image;
                    _context.Add(_predio);
                    _context.Entry(_predio).State = _predio.Id > 0 ? EntityState.Modified : EntityState.Added;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }
            return get;
        }
        /// <summary>
        /// Obtiene toda la cabecera del area de prospeccion
        /// </summary>
        /// <param name="id"> Id del area prospectada</param>
        /// <returns></returns>
        public ZonaProspectada ObteneZonaProspectada(int id)
        {
            var _zonaProspectada = _context.ZonaProspectada.Where(x => x.Id.Equals(id));
            if(_zonaProspectada.Count()>0)
            return _zonaProspectada.First();
            else
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<PredioViewModel> ObtenePredios(int id)
        {
            var _predio = _context.Predio.Where(x => x.IdZonaProspectada.Equals(id));
            Mapper.Reset();
            if (_predio.Count() > 0) { 
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Predio, PredioViewModel >();
                });

            var _model = Mapper.Map<List<PredioViewModel>>(_predio.ToList());
            return _model;
        }
            else { return null; }
                
        }


        public IList<Propietario> ObtenePropietario(int id)
        {
            var _propietario = _context.Propietario.Where(x => x.Id.Equals(id));
 
            if (_propietario.Count() > 0)
            {
           
                var _model = _propietario.ToList();
                return _model;
            }
            else { return null; }

        }

        /// <summary>
        /// Retorna todos los Propietarios
        /// </summary>
        /// <returns></returns>
        public IList<Propietario> GetPropietario()
        {
            var _propietario = _context.Propietario.ToList();
            return _propietario;

        }

        public IList<PredioViewModel> ObtenePredioId(int id)
        {
            var _predio = _context.Predio.Where(x => x.Id.Equals(id));
            Mapper.Reset();
            if (_predio.Count() > 0)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Predio, PredioViewModel>();
                });

                var _model = Mapper.Map<List<PredioViewModel>>(_predio.ToList());
                return _model;
            }
            else { return null; }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<PredioViewModelTab> ObtenePrediosCamposTab(int id)
        {
            var _predio = from b in _context.Predio
                          where b.IdZonaProspectada.Equals(id)
                          select new { b.Id, b.IdZonaProspectada,b.Name };
            Mapper.Reset();
            if (_predio.Count() > 0)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Predio, PredioViewModelTab>();
                });

                var _model = Mapper.Map<List<PredioViewModelTab>>(_predio.ToList());
                return _model;
            }
            else { return null; }

        }


        public IList<TaskViewModel> ObtenerTareas(int id)
        {
            var _tasks = _context.Task
                               .Include(x => x.detailtaks)
                               .Where(z => z.IdPredio.Equals(id)).ToList();

            Mapper.Reset();
            if (_tasks.Count() > 0)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Realstate.Models.BaseDatos.Task, TaskViewModel>();
                });

                var _model = Mapper.Map<List<TaskViewModel>>(_tasks.ToList());
                return _model;
            }
            return null;

        }

        public IList<TaskViewModel> ObtenerTareasini(int id)
        {
            var _tasks = _context.Task
                               .Include(x => x.detailtaks)
                               .Where(z => z.IdTypeTask.Equals(id)).ToList();

            Mapper.Reset();
            if (_tasks.Count() > 0)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Realstate.Models.BaseDatos.Task, TaskViewModel>();
                });

                var _model = Mapper.Map<List<TaskViewModel>>(_tasks.ToList());
                return _model;
            }
            return null;

        }
        public IList<TaskViewModel> ObtenerTareasbyId(int id)
        {
            var _tasks = _context.Task
                               .Include(x => x.detailtaks)
                               .Where(z => z.Id.Equals(id)).ToList();

            Mapper.Reset();
            if (_tasks.Count() > 0)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Realstate.Models.BaseDatos.Task, TaskViewModel>();
                });

                var _model = Mapper.Map<List<TaskViewModel>>(_tasks.ToList());
                return _model;
            }
            return null;

        }
        public int GuardarAreas_task(string coment , int idpredio , String destinatario, String asunto, int tipo, string adjunto, string usuario,string fechatask)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                Realstate.Models.BaseDatos.Task _task = new Realstate.Models.BaseDatos.Task();
                _task.IdPredio=idpredio;
                _task.IdAccount = 3;
                _task.IdStatusTask = 1;
                _task.Usercreation = usuario;
                _task.IdTypeTask = tipo;
                _task.StartDate = DateTime.Now;
                _task.DateModification = DateTime.Now;
                _task.DateCreation = DateTime.Now;
                _task.DateValidation = DateTime.Now;
                _task.DateValidation = DateTime.Now;
                _task.StatusRegister = "A";
                _context.Add(_task);
                _context.Entry(_task).State = EntityState.Added;

                var get = _context.SaveChanges();
                if (_task.IdTypeTask == 1) { 
                   DetailTask _taskDetail = new DetailTask();

                _taskDetail.coment = coment;
                _taskDetail.attached = adjunto;
                _taskDetail.creation_date= DateTime.Now;
                _taskDetail.creation_meeting= DateTime.Now;
                _taskDetail.ENDMeting = DateTime.Now;
                _taskDetail.IdTask = _task.Id;
                _context.Add(_taskDetail);
                _context.Entry(_taskDetail).State = EntityState.Added;
                 get = _context.SaveChanges();
                    }
                if (_task.IdTypeTask == 2)
                {

                    DetailTask _taskDetail = new DetailTask();

                    _taskDetail.coment = coment;
                    _taskDetail.attached = adjunto;
                    _taskDetail.creation_date = DateTime.Now;
                    _taskDetail.creation_meeting = DateTime.Now;
                    _taskDetail.ENDMeting = DateTime.Now;
                    _taskDetail.IdTask = _task.Id;
                    _taskDetail.subjects = asunto;
                    _taskDetail.addressee = destinatario;
                    _context.Add(_taskDetail);
                    _context.Entry(_taskDetail).State = EntityState.Added;
                    get = _context.SaveChanges();
                }

                if (_task.IdTypeTask == 4)
                {

                    DetailTask _taskDetail = new DetailTask();
                    

                    string[] separadas;

                    separadas = fechatask.Split('-');


                    _taskDetail.coment = coment;
                    _taskDetail.attached = adjunto;
                    _taskDetail.creation_date = DateTime.Now;
                    _taskDetail.creation_meeting = Convert.ToDateTime(separadas[0].Trim());
                    _taskDetail.ENDMeting = Convert.ToDateTime( separadas[1].Trim());
                    _taskDetail.IdTask = _task.Id;
                    _taskDetail.subjects = asunto;
                   
                    _context.Add(_taskDetail);
                    _context.Entry(_taskDetail).State = EntityState.Added;
                    get = _context.SaveChanges();
                }

                if (_task.IdTypeTask == 6)
                {

                    DetailTask _taskDetail = new DetailTask();


                    string[] separadas;

                    separadas = fechatask.Split('-');


                    _taskDetail.coment = coment;
                    _taskDetail.attached = adjunto;
                    _taskDetail.creation_date = DateTime.Now;
                    _taskDetail.creation_meeting = Convert.ToDateTime(separadas[0].Trim());
                    _taskDetail.ENDMeting = Convert.ToDateTime(separadas[1].Trim());
                    _taskDetail.IdTask = _task.Id;
                    _taskDetail.subjects = asunto;
                    _taskDetail.attached = adjunto;
                    _taskDetail.addressee = destinatario;
                    _context.Add(_taskDetail);
                    _context.Entry(_taskDetail).State = EntityState.Added;
                    get = _context.SaveChanges();
                }
                transaction.Commit();
                return _task.Id;
            }
           
        }
        public int deletePredidios(int AreaProspeccion)
        {

            int get = -1;
            try
            {
                var _task = _context.Task.Where(x => x.IdPredio.Equals(AreaProspeccion)).Count();
                if (_task == 0)
                {
                    var _predio = _context.Predio.SingleOrDefault(m => m.Id == AreaProspeccion);
                    _context.Predio.Remove(_predio);
                    get = _context.SaveChanges();
                    return 1;
                }
                
            }
            catch (Exception)
            {

                return 0;
            }
            return get;
        }

    }
}
