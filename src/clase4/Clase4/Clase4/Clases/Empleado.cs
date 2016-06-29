using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase4.Clases
{
    /// <summary>
    /// Representa un empleado, el cual es una extension de una persona
    /// </summary>
    public class Empleado : Persona
    {
        /// <summary>
        /// Obtiene o establece el sueldo del empleado
        /// </summary>
        public double Sueldo { get; set; }
    }
}
