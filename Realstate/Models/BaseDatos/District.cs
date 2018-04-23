using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class District
    {
        public District()
        {
            Sector = new HashSet<Sector>();
            Zona = new HashSet<Zona>();
        }

        public int Id { get; set; }
        public int IdProvince { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }
        public long? IdManagement { get; set; }

        public Management IdManagementNavigation { get; set; }
        public Province IdProvinceNavigation { get; set; }
        public ICollection<Sector> Sector { get; set; }
        public ICollection<Zona> Zona { get; set; }
    }
}
