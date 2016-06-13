using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1();

            Ejercicio2();

            Console.ReadKey();
        }

        private static void Ejercicio1()
        {
            // Opción 1.
            int resultado = 0;
            for (int i = 1; i <= 10; i++)
            {
                if (i == 4 || i == 5)
                    continue;

                resultado = resultado + i;

                Console.WriteLine(resultado);
            }

            // Opción 2.
            resultado = 0;
            int j = 1;
            while (j <= 10)
            {
                if (j < 4 || j > 5)
                {
                    resultado = resultado + j;
                    Console.WriteLine(resultado);
                }

                j++;
            }
        }

        private static void Ejercicio2()
        {
            // Opción 1.
            for (int i = 2; i <= 10; i = i + 2)
            {
                Console.WriteLine(i);
            }

            // Opción 2.
            for (int i = 1; i <= 10; i++)
            {
                // Si no sobra nada al dividir el numero entre dos
                // quiere decir que el numero es par.
                if (i % 2 == 0)
                    Console.WriteLine(i);
            }
        }
    }
}
