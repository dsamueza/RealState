using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Management
    {
        public Management()
        {
            District = new HashSet<District>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long IdRegion { get; set; }

        public Region IdRegionNavigation { get; set; }
        public ICollection<District> District { get; set; }
    }
}
