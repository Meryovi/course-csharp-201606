using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /// <summary>
    /// Representa una cuenta.
    /// No se puede crear una instancia de la clase cuenta, debido a que es abstracta.
    /// Las clases abstractas se utilizan para implementar la funcionalidad base de otras clases.
    /// </summary>
    public abstract class Cuenta
    {
        /// <summary>
        /// Cliente dueño de la cuenta.
        /// </summary>
        public Cliente Dueno { get; set; }

        /// <summary>
        /// Balance de la cuenta. Puede ser leído por todos, pero solo puede ser modificado
        /// por la clase cuenta y las clases que hereden de ella.
        /// </summary>
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Realiza un crédito a la cuenta.
        /// Este método no puede ser sobrescrito normalmente por las clases hijas.
        /// </summary>
        /// <param name="valor">Valor del crédito</param>
        /// <returns>Balance luego del crédito</returns>
        public decimal RealizarCredito(decimal valor)
        {
            Balance += valor;
            return Balance;
        }

        /// <summary>
        /// Realiza un débito a la cuenta.
        /// Este método es virtual, lo que quiere decir que puede ser sobrescrito por clases hijas.
        /// </summary>
        /// <param name="valor">Valor del débito</param>
        /// <returns>Balance luego del débito</returns>
        public virtual decimal RealizarDebito(decimal valor)
        {
            Balance -= valor;
            return Balance;
        }
    }
}
