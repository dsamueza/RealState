using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Realstate.Models.BaseDatos
{
    public partial class Project
    {
        public Project()
        {
            ZonaProspectada = new HashSet<ZonaProspectada>();
        }
        [Required]
        public int Id { get; set; }
        [Display(Name = "Cuenta")]
        public int IdAccount { get; set; }
        public string Code { get; set; }
        [Required]
        [Display(Name = "Nombre Proyecto")]
        public string Name { get; set; }
        [Display(Name = "País")]
        [Required]
        public int? IdContry { get; set; }
        [Required]
        [Display(Name = "Provincia")]
        public int? IdProvince { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public int? IdDistrict { get; set; }
        [Display(Name = "Parroquia")]
        [Required]
        public int? IdParish { get; set; }
        [Required]
        [Display(Name = "Sector")]
        public int? IdSector { get; set; }
        [Required]
        [Display(Name = "Link Geoserver")]
        public int? IdLink { get; set; }
        [Required]
        [Display(Name = "Zona")]
        public int? ZonaId { get; set; }
        [Display(Name = "Imagen Proyecto")]
       
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
        public string Usercreation { get; set; }
        public string StatusRegister { get; set; }

       
        public Account IdAccountNavigation { get; set; }
        public Country IdContryNavigation { get; set; }
        public District IdDistrictNavigation { get; set; }
        public Link IdLinkNavigation { get; set; }
        public Parish IdParishNavigation { get; set; }
        public Province IdProvinceNavigation { get; set; }
        public Sector IdSectorNavigation { get; set; }
        public Zona Zona { get; set; }
        public ICollection<ZonaProspectada> ZonaProspectada { get; set; }
    }
}
