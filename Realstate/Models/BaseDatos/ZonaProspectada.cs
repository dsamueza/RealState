using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class ZonaProspectada
    {
        public ZonaProspectada()
        {
            Predio = new HashSet<Predio>();
        }

        public int Id { get; set; }
        public int? IdProyecto { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StreetMain { get; set; }
        public string StreetSecundary { get; set; }
        public string Streetthree { get; set; }
        public string Streetfour { get; set; }
        public string Reference { get; set; }
        public string Zona { get; set; }
        public string Commentary { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Usercreation { get; set; }
        public string StatusRegister { get; set; }

        public Project IdProyectoNavigation { get; set; }
        public ICollection<Predio> Predio { get; set; }
    }
}
