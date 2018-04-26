using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class Propietario
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Movil { get; set; }
        public string Email { get; set; }
    }
}
