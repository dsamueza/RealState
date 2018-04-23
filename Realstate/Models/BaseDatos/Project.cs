using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
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
        public int? IdZona { get; set; }
        public DateTime CreationDate { get; set; }
        public int IdTypeProject { get; set; }
        public string StatusRegister { get; set; }

        public TypeProject IdTypeProjectNavigation { get; set; }
        public Zona IdZonaNavigation { get; set; }
        public Account IdAccountNavigation { get; set; }
        public ICollection<ProspectoAreas> ProspectoAreas { get; set; }
    }
}
