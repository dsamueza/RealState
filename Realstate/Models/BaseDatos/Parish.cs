using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Parish
    {
        public Parish()
        {
            Zona = new HashSet<Zona>();
        }

        public int Id { get; set; }
        public int IdDistrict { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }

        public ICollection<Zona> Zona { get; set; }
    }
}
