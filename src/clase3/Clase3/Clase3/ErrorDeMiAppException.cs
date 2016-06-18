using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase3
{
    public class ErrorDeMiAppException : Exception
    {
        public ErrorDeMiAppException()
            : base("Hubo un error en mi aplicación")
        {

        }
    }
}
