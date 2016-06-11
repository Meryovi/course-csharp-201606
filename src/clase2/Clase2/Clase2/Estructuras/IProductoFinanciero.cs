using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    public interface IProductoFinanciero
    {
        decimal Balance { get; }

        void Abrir();

        void Cerrar();
    }
}
