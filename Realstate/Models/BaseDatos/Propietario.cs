using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Realstate.Models.BaseDatos
{
    public partial class Propietario
    {
        public int Id { get; set; }
        
        [Display(Name = "Cédula")]
        [ClassicMovie(1956)]
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

    public class ClassicMovieAttribute : ValidationAttribute
    {
        private int _year;

        public ClassicMovieAttribute(int Year)
        {
            _year = Year;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Propietario p = validationContext.ObjectInstance as Propietario;

            if (p.Cedula == "12345")
            {
                return new ValidationResult("Invalid country.Valid values are USA, UK, and India.");
            }

            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return "Classic movies must have a release year earlier than.";
        }
    }
}
