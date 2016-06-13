using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /// <summary>
    /// La cuenta de ahorro es una cuenta y por consiguiente hereda todas las propiedades de una.
    /// </summary>
    public class CuentaAhorro : Cuenta
    {
        /// <summary>
        /// Las cuentas de ahorro tienen una tasa de interés.
        /// </summary>
        public double TasaInteres { get; set; }

        /// <summary>
        /// Las cuentas de ahorro tienen la restricción de que al realizarse un débito, el balance
        /// nunca puede quedar por debajo de cero. Como la clase Cuenta no tiene esta restricción, debemos
        /// sobrescribir el método que permite realizar los débitos para agregar esta característica.
        /// </summary>
        /// <param name="valor">Valor del débito</param>
        /// <returns>Balance luego del débito</returns>
        public override decimal RealizarDebito(decimal valor)
        {
            if (Balance - valor < 0)
            {
                Console.WriteLine("El valor del débito excede el balance de la cuenta");
                return Balance;
            }

            Balance -= valor;
            return Balance;
        }
    }
}