using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Sector
    {
        public Sector()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public int IdDistrict { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }

        public District IdDistrictNavigation { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
