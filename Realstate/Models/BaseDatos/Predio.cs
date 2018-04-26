using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Predio
    {
        public Predio()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int? IdZonaProspectada { get; set; }
        public string Name { get; set; }
        public string Zona { get; set; }
        public string Value { get; set; }
        public byte[] Image { get; set; }
        public string Latitude { get; set; }
        public string Length { get; set; }
        public int? IdPropietario { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Usercreation { get; set; }
        public string StatusRegister { get; set; }

        public ZonaProspectada IdZonaProspectadaNavigation { get; set; }
        public ICollection<Task> Task { get; set; }
    }
}
