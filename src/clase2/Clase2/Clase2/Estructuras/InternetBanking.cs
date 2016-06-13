using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    /// <summary>
    /// En este caso la clase InternetBanking es estática, lo que quiere decir que existe una instancia única en la memoria del equipo
    /// y esta instancia se maneja de forma automática. Para fines del desarrollador, no es necesario crear una instancia utilizando el
    /// operador NEW y puede ser utilizada escribiendo su nombre y el método a ejecutar.
    /// Las clases estáticas usualmente se utilizan para métodos de utilitario o funcionalidades generales de la aplicación que no
    /// ameritan una instancia para cada uso. Se prefiere para uso general de la aplicación clases NO estáticas (de instancia).
    /// Se considera una mala practica incluir en las clases estáticas propiedades o atributos, a menos que estos sean fijos. Esto porque
    /// puede introducir errores si las propiedades son modificadas en cualquier punto de la aplicación.
    /// </summary>
    public static class InternetBanking
    {
        /// <summary>
        /// Notifica que un usuario ha iniciado sesión.
        /// </summary>
        /// <param name="cliente">Cliente que inicio la sesión</param>
        public static void IniciarSesion(Cliente cliente)
        {
            Console.WriteLine("Iniciada sesión como " + cliente.Nombre);
        }

        /// <summary>
        /// Debita una cuenta de ahorro.
        /// Este método solo sera llamado si se envía una cuenta de ahorro. Esto es una modalidad de polimorfismo.
        /// </summary>
        /// <param name="cuentaAhorro">Cuenta de ahorro</param>
        /// <param name="monto">Monto del débito</param>
        public static void DebitarCuenta(CuentaAhorro cuentaAhorro, decimal monto)
        {
            cuentaAhorro.RealizarDebito(monto);

            Console.WriteLine("El dueño de la cuenta es: " + cuentaAhorro.Dueno.Nombre);
            Console.WriteLine("Y esto es una cuenta de ahorro");
        }

        /// <summary>
        /// Debita una cuenta, independientemente su tipo.
        /// Este método nunca sera llamado para las cuentas de ahorro, debido a que existe una sobrecarga que recibe específicamente
        /// una cuenta de ese tipo.
        /// </summary>
        /// <param name="cuenta">Cuenta</param>
        /// <param name="monto">Monto del débito</param>
        public static void DebitarCuenta(Cuenta cuenta, decimal monto)
        {
            cuenta.RealizarDebito(monto);

            Console.WriteLine("El dueño de la cuenta es: " + cuenta.Dueno.Nombre);
            Console.WriteLine("El balance es: " + cuenta.Balance);
        }
    }
}
