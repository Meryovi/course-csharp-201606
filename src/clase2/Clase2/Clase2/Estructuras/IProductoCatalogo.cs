using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /// <summary>
    /// Esta interfaz indica que un producto es del catalogo de productos, por lo cual debe tener
    /// un balance accesible y debe poder ser abierto y cerrado.
    /// </summary>
    public interface IProductoCatalogo
    {
        /// <summary>
        /// Balance del producto.
        /// </summary>
        decimal Balance { get; }

        /// <summary>
        /// Abre el producto. Este método deberá ser definido por todas las clases
        /// que implementen esta interfaz.
        /// </summary>
        void Abrir();

        /// <summary>
        /// Cierra el producto. Este método deberá ser definido por todas las clases
        /// que implementen esta interfaz.
        /// </summary>
        void Cerrar();
    }
}
