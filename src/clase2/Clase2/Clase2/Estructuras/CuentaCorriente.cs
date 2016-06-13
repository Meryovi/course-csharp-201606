using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /// <summary>
    /// La cuenta corriente es una cuenta y por consiguiente hereda todas las propiedades de una.
    /// También decimos en este caso que es un producto del catalogo, por lo cual se puede abrir o cerrar.
    /// </summary>
    public class CuentaCorriente : Cuenta, IProductoCatalogo
    {
        /// <summary>
        /// Abre la cuenta corriente.
        /// </summary>
        public void Abrir()
        {
            Console.WriteLine("La cuenta corriente fue abierta");
        }

        /// <summary>
        /// Cierra la cuenta corriente.
        /// </summary>
        public void Cerrar()
        {
            Console.WriteLine("La cuenta corriente fue cerrada");
        }
    }
}
