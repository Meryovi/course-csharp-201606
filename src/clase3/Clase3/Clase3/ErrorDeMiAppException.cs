using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase3
{
    public class ErrorDeMiAppException : Exception
    {
        // Definimos una excepción personalizada para nuestra aplicación.

        public ErrorDeMiAppException()
            : base("Hubo un error en mi aplicación")
        {

        }
    }
}
