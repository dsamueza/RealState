using Realstate.Models.BaseDatos;
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
            var get= _context.SaveChanges();
            return get;
        }
    }
}
