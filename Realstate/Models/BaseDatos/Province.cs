using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Province
    {
        public Province()
        {
            District = new HashSet<District>();
            Zona = new HashSet<Zona>();
        }

        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Country IdCountryNavigation { get; set; }
        public ICollection<District> District { get; set; }
        public ICollection<Zona> Zona { get; set; }
    }
}
