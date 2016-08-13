using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoFacturas.Core.Utils
{
    public static class ClientesUtils
    {
        public static bool EsCedulaValida(string cadena)
        {
            return Regex.IsMatch(cadena, "^[0-9]{3}[0-9]{7}[0-9]$");
        }
    }
}
