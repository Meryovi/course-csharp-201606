using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase4.Clases
{
    /// <summary>
    /// Representa una persona
    /// </summary>
    public class Persona
    {
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
