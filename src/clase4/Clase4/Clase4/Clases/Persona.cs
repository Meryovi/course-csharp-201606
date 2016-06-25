using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase4.Clases
{
    public class Persona
    {
        public string Nombre { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad
        {
            // Propiedad de solo lectura (solo tiene get, no set).
            get
            {
                int edad = (DateTime.Today - FechaNacimiento).Days / 365;
                return edad;
            }
        }

        public Persona()
        {

        }
    }
}
