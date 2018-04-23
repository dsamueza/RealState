using System;
using System.Collections.Generic;

namespace Realstate.Models
{
    public partial class Project
    {
        public Project()
        {
            ProspectoAreas = new HashSet<ProspectoAreas>();
        }

        public int Id { get; set; }
        public int IdAccount { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdCountry { get; set; }
        public int IdProvince { get; set; }
        public int IdDistrict { get; set; }
        public int IdParish { get; set; }
        public int IdSector { get; set; }
        public int IdTypeProject { get; set; }
        public string StatusRegister { get; set; }

        public Country IdCountryNavigation { get; set; }
        public District IdDistrictNavigation { get; set; }
        public Parish IdParishNavigation { get; set; }
        public Province IdProvinceNavigation { get; set; }
        public Sector IdSectorNavigation { get; set; }
        public TypeProject IdTypeProjectNavigation { get; set; }
        public ICollection<ProspectoAreas> ProspectoAreas { get; set; }
    }
}
