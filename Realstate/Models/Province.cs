using System;
using System.Collections.Generic;

namespace Realstate.Models
{
    public partial class Province
    {
        public Province()
        {
            District = new HashSet<District>();
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Country IdCountryNavigation { get; set; }
        public ICollection<District> District { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
