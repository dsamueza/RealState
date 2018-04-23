using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Region
    {
        public Region()
        {
            Management = new HashSet<Management>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Management> Management { get; set; }
    }
}
