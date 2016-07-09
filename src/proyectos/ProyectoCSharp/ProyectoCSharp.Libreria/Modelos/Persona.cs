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
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la persona
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el sexo de la persona
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento de la persona
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la persona es empleado
        /// </summary>
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
