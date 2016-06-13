using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /// <summary>
    /// Esta clase representa un cliente, lo cual es una extension de una persona.
    /// Esto quiere decir que la clase Cliente asume todas las informaciones de una Persona
    /// y puede incluir datos adicionales.
    /// </summary>
    public class Cliente : Persona
    {
        /// <summary>
        /// Esta propiedad solo esta disponible para instancias de tipo Cliente.
        /// </summary>
        public decimal FondoCompra { get; set; }

        /// <summary>
        /// Los clientes pueden comprar un articulo.
        /// </summary>
        /// <param name="articulo">Nombre del articulo adquirido por los clientes</param>
        public void Comprar(string articulo)
        {
            Console.WriteLine(Nombre + " compro un " + articulo);
        }
    }
}
