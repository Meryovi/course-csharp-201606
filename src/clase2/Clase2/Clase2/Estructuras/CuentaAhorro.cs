using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    public class CuentaAhorro : Cuenta
    {
        public double TasaInteres { get; set; }

        public override decimal RealizarDebito(decimal valor)
        {
            if (Balance - valor < 0)
            {
                Console.WriteLine("El valor del debito excede el balance de la cuenta");
                return Balance;
            }

            Balance -= valor;
            return Balance;
        }
    }
}