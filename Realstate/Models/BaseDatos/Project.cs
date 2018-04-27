using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Project
    {
        public Project()
        {
            ZonaProspectada = new HashSet<ZonaProspectada>();
        }

        public int Id { get; set; }
        public int IdAccount { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? IdContry { get; set; }
        public int? IdProvince { get; set; }
        public int? IdDistrict { get; set; }
        public int? IdParish { get; set; }
        public int? IdSector { get; set; }
        public int? IdLink { get; set; }
        public int? ZonaId { get; set; }
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
