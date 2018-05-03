using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realstate.Models.Struct
{
    public class PredioViewModel
    {

        //IdProyecto: 0,
        //        IdPredio: 0,
        //        Secuencial: 0,
        //        Nombre: '',
        //        Zona: '',
        //        Dimension: '',
        //        latitud: '',
        //        longitud: '',
        //        Propietario: '',
        //        Estado: '',
        //        imagen: ''
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdZonaProspectada { get; set; }
        public int Secuencial { get; set; }
        public int IdPropietario { get; set; }
        public string Name { get; set; }
        public string Zona { get; set; }
        public string Value { get; set; }

        public string Latitude { get; set; }
        public string Length { get; set; }
        public string StatusRegister { get; set; }
        public string Image { get; set; }
    }
}
