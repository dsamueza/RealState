using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Zona
    {
        public Zona()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usercreation { get; set; }
        public string StatusRegister { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
