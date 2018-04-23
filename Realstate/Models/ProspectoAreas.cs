using System;
using System.Collections.Generic;

namespace Realstate.Models
{
    public partial class ProspectoAreas
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Zone { get; set; }
        public string Neighborhood { get; set; }
        public string MainStreet { get; set; }
        public string SecundaryStreet { get; set; }
        public string Reference { get; set; }
        public string StatusRegister { get; set; }

        public Project IdProjectNavigation { get; set; }
    }
}
