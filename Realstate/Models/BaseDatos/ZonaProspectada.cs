using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Realstate.Models.BaseDatos
{
    public partial class ZonaProspectada
    {
        public ZonaProspectada()
        {
            Predio = new HashSet<Predio>();
        }

        public int Id { get; set; }
        [DisplayName("Proyecto")]
        public int? IdProyecto { get; set; }
        [DisplayName("Código")]
        public string Code { get; set; }
        [DisplayName("Nombre del Área")]
        public string Name { get; set; }
        [DisplayName("Calle Principal")]
        public string StreetMain { get; set; }
        [DisplayName("Calle Secundaria")]
        public string StreetSecundary { get; set; }

        public string Streetthree { get; set; }

        public string Streetfour { get; set; }
        [DisplayName("Referencia")]
        public string Reference { get; set; }
        [DisplayName("Zona")]
        public string Zona { get; set; }
        [DisplayName("Comentario")]
        public string Commentary { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Usercreation { get; set; }
        public string StatusRegister { get; set; }

        public Project IdProyectoNavigation { get; set; }
        public ICollection<Predio> Predio { get; set; }
    }
}
