using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Country
    {
        public Country()
        {
            Province = new HashSet<Province>();
            Zona = new HashSet<Zona>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }

        public ICollection<Province> Province { get; set; }
        public ICollection<Zona> Zona { get; set; }
    }
}
