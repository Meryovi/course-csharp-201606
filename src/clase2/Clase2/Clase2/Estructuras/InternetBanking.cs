using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    public static class InternetBanking
    {
        public static void IniciarSesion(Cliente cliente)
        {
            Console.WriteLine("Iniciada sesion como " + cliente.Nombre);
        }

        public static void DebitarCuenta(CuentaAhorro cuentaAhorro, decimal monto)
        {
            cuentaAhorro.RealizarDebito(monto);

            Console.WriteLine("El dueño de la cuenta es: " + cuentaAhorro.Dueno.Nombre);
            Console.WriteLine("Y esto es una cuenta de ahorro");
        }

        public static void DebitarCuenta(Cuenta cuenta, decimal monto)
        {
            cuenta.RealizarDebito(monto);

            Console.WriteLine("El dueño de la cuenta es: " + cuenta.Dueno.Nombre);
            Console.WriteLine("El balance es: " + cuenta.Balance);
        }
    }
}
