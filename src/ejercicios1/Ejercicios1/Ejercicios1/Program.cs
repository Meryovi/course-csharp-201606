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
            for (int i = 1; i <= 10; i++)
            {
                if (i != 4 && i != 5)
                {
                    Console.WriteLine(i);
                }
            }

            // Opción 3.
            for (int i = 2; i <= 10; i = i + 2)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
