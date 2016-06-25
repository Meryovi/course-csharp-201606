using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio2();
        }

        private static void Ejercicio1()
        {
            var listaCompras = new List<string>();
            
            // Leyendo los articulos que formaran parte de la lista de compras.
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Digite el articulo #" + (i + 1) + ": ");
                string articulo = Console.ReadLine();

                listaCompras.Add(articulo);
            }

            // Removemos el cuarto articulo, porque ya no sera necesario.
            listaCompras.RemoveAt(4);

            Console.WriteLine();
            Console.WriteLine("Lista de compras:");

            foreach (var articulo in listaCompras)
            {
                Console.WriteLine(articulo);
            }

            Console.ReadKey();
        }

        private static void Ejercicio2()
        {
            string cedula, nombre, edad, nombreArchivo;

            Console.WriteLine("Digite la cédula de la persona:");
            cedula = Console.ReadLine();

            Console.WriteLine("Digite el nombre de la persona:");
            nombre = Console.ReadLine();

            Console.WriteLine("Digite la edad:");
            edad = Console.ReadLine();

            nombreArchivo = cedula + ".txt";

            if (File.Exists(nombreArchivo))
            {
                Console.WriteLine("Esta persona ya existe");
            }
            else
            {
                string[] lineas = new string[] { cedula, nombre, edad };
                File.WriteAllLines(nombreArchivo, lineas);
            }

            Console.ReadKey();
        }
    }
}
