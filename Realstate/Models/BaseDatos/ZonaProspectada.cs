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
        [Required]
        public string Code { get; set; }
        [DisplayName("Nombre del Área")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Calle N° 1")]
        public string StreetMain { get; set; }
        [Required]
        [DisplayName("Calle N° 2")]
        public string StreetSecundary { get; set; }
        [DisplayName("Calle N° 3")]
        public string Streetthree { get; set; }
        [DisplayName("Calle N° 4")]
        public string Streetfour { get; set; }
        [DisplayName("Referencia")]
        [Required]
        public string Reference { get; set; }
        [DisplayName("Área m²")]

        public string Zona { get; set; }
        [DisplayName("Comentario")]
        public string Commentary { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Usercreation { get; set; }
        public string StatusRegister { get; set; }
        public string imagen { get; set; }

        public Project IdProyectoNavigation { get; set; }
        public ICollection<Predio> Predio { get; set; }
    }
}
