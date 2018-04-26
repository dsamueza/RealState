using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Country
    {
        public Country()
        {
            Project = new HashSet<Project>();
            Province = new HashSet<Province>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StatusRegister { get; set; }

        public ICollection<Project> Project { get; set; }
        public ICollection<Province> Province { get; set; }
    }
}
