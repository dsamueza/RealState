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
            var project = _context.Project.Where(x => x.Id.Equals(id)).First().Name;
            return project;
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
    }
}
