using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class District
    {
        public District()
        {
            Project = new HashSet<Project>();
            Sector = new HashSet<Sector>();
        }

        public int Id { get; set; }
        public int IdProvince { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }
        public long? IdManagement { get; set; }

        public Management IdManagementNavigation { get; set; }
        public Province IdProvinceNavigation { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<Sector> Sector { get; set; }
    }
}
