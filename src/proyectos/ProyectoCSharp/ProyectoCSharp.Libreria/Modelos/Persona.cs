using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCSharp.Libreria.Modelos
{
    /// <summary>
    /// Representa una persona
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Obtiene o establece la identificación de la persona
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Debe completar la identificación")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la persona
        /// </summary>
        [Required(ErrorMessage = "No podemos registrar una persona sin nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el sexo de la persona
        /// </summary>
        [Required(ErrorMessage = "La persona debe tener un sexo")]
        public string Sexo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento de la persona
        /// </summary>
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la persona es empleado
        /// </summary>
        [Display(Name = "Es Empleado?")]
        public bool EsEmpleado { get; set; }

        /// <summary>
        /// Obtiene o establece el sueldo de la persona
        /// </summary>
        public decimal? Sueldo { get; set; }

        /// <summary>
        /// Obtiene la edad actual de la persona
        /// </summary>
        public int Edad
        {
            // Propiedad de solo lectura (solo tiene get, no set).
            get
            {
                int edad = (DateTime.Today - FechaNacimiento).Days / 365;
                return edad;
            }
        }
    }
}
