using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    public abstract class Cuenta
    {
        public Cliente Dueno { get; set; }

        public decimal Balance { get; protected set; }

        public decimal RealizarCredito(decimal valor)
        {
            Balance += valor;
            return Balance;
        }

        public virtual decimal RealizarDebito(decimal valor)
        {
            Balance -= valor;
            return Balance;
        }
    }
}
