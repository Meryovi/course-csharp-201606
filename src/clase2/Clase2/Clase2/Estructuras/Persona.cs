using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /*
     * Modificadores de acceso:
     * 
     * public: La clase o propiedad puede ser accedida dentro o fuera de la clase, por otras clases y en instancias de la clase.
     * protected: La propiedad solo puede ser accedida dentro de la clase o por clases hijas.
     * private: La propiedad solo puede ser accedida dentro de la clase.
     * internal: La clase solo puede ser accedida dentro del proyecto actual.
     */

    /// <summary>
    /// Esta clase representa una persona con sus informaciones básicas.
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Obtiene o establece el nombre de la persona
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido de la persona
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Permite a esta clase o clases hijas leer la edad del cliente, pero solo esta clase
        /// puede cambiar su valor
        /// </summary>
        protected int Edad { get; private set; }

        /// <summary>
        /// Las personas pueden saltar.
        /// </summary>
        public void Saltar()
        {
            Console.WriteLine(Nombre + " salto");
        }
    }
}
