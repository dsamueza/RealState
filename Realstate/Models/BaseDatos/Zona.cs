using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Zona
    {
        public Zona()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Reference { get; set; }
        public string Propietario { get; set; }
        public int? IdCountry { get; set; }
        public int? IdProvince { get; set; }
        public int? IdDistrict { get; set; }
        public int? IdParish { get; set; }
        public int? IdSector { get; set; }
        public string Latitude { get; set; }
        public string Length { get; set; }
        public string Zona1 { get; set; }
        public string Avaluo { get; set; }
        public string StreetMain { get; set; }
        public string StreetSecundary { get; set; }
        public string Streetthree { get; set; }
        public string Streetfour { get; set; }
        public string Commentary { get; set; }
        public string Photo { get; set; }
        public string Linkgeo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string StatusRegister { get; set; }

        public Country IdCountryNavigation { get; set; }
        public District IdDistrictNavigation { get; set; }
        public Parish IdParishNavigation { get; set; }
        public Province IdProvinceNavigation { get; set; }
        public Sector IdSectorNavigation { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
