using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo...");

            // Valores numéricos enteros.
            int numero = 1 + 1;
            short numeroShort = 1;
            long numeroLong = 1;
            byte numeroByte = 1;

            System.Int32 int32 = 1;
            System.Int16 int16;
            System.Int64 int64;
            System.Byte sysByte;

            // Valores numéricos flotantes.
            double doble = 1.00;
            float flotante = 1.00f;
            decimal numeroDecimal = 1.00M;

            System.Double sysDouble;
            System.Single sysSingle;
            System.Decimal sysDecimal;

            // Valores alfanuméricos.
            char caracter = 'b';
            string cadena = "Cadena de texto";

            System.Char sysChar;
            System.String sysString;

            // Valor booleano.
            bool booleano = true;
            bool booleanoFalse = false;

            System.Boolean sysBool;

            // Estructuras de control.
            // IF se utiliza para verificar si una condición es verdadera
            // y ejecuta cierta lógica si lo es.
            // ELSE es la contra-parte del IF. En una sentencia IF, el ELSE
            // se ejecuta si la condición no es verdadera.
            if (caracter == 'a')
            {
                Console.WriteLine("El caracter es a minuscula");
            }
            else
            {
                Console.WriteLine("El caracter no es a minuscula...");
            }

            // La sentencia SWITCH permite verificar entre un conjunto de opciones
            // definidas y ejecutar un fragmento de código de acuerdo al caso.
            // En caso de que el valor no se adapte a ninguna de las opciones definidas
            // se ejecuta lo indicado en la sección DEFAULT.
            switch (caracter)
            {
                case 'a':
                    Console.WriteLine("El caracter es a");
                    break;
                case 'b':
                    Console.WriteLine("El caracter es b");
                    break;
                default:
                    Console.WriteLine("Es un caracter distinto a a o b");
                    break;
            }

            // Estructuras de control repetitivas.
            // WHILE se utiliza para repetir un fragmento de código
            // mientras la condición evaluada sea verdadera.
            int numerox = 0;
            while (numerox <= 10)
            {
                Console.WriteLine(numerox);
                numerox = numerox + 1;
            }

            // DO..WHILE se utiliza cuando necesitamos que el fragmento
            // de código sea ejecutado al menos una vez.
            numerox = 0;
            do
            {
                Console.WriteLine(numerox);
                numerox = numerox + 1;
            }
            while (numerox <= 10);

            // FOR es utilizado para repetir una condición un numero definido
            // de veces. Es la estructura repetitiva mas popular.
            for (int i = 0; i <= 10; i = i + 1)
            {
                Console.WriteLine(i);
            }
            
            Console.ReadKey();
        }
    }
}
