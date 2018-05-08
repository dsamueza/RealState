using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Realstate.Models.BaseDatos
{
    public partial class Propietario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduce la Cédula del propietario")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Introduce el nombre del propietario")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [Display(Name = "Celular")]
        public string Movil { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
