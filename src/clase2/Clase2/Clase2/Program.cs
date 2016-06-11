using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase2.Estructuras;

namespace Clase2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente();

            cliente.Nombre = "Meryovi";
            cliente.Apellido = "De Dios";

            InternetBanking.IniciarSesion(cliente);

            var cuenta = new CuentaAhorro();
            cuenta.Dueno = cliente;

            if (cuenta is IProductoFinanciero)
                Console.WriteLine("Es un producto financiero");
            else
                Console.WriteLine("No es un producto financiero");

            InternetBanking.DebitarCuenta(cuenta, 1000);

            Console.ReadKey();
        }

        private static void ListasGenericas()
        {
            // Arreglo compuesto por tres valores: 1, 2, 4
            var arreglos = new int[] { 1, 2, 4 };

            // Lista generica que permite agregar o remover valores de forma dinamica.
            // Las listas genericas permiten crear listas de cualquier tipo.
            var listaEnteros = new List<int>() { 1, 2, 4 };
            listaEnteros.Add(5);
            listaEnteros.Remove(2);

            // Para recorrer los valores de una lista generica, se utiliza la
            // instruccion foreach.
            foreach (var entero in listaEnteros)
                Console.WriteLine(entero);

            // Los diccionarios permiten agrupar una llave unica y un valor.
            var diccionarioNotas = new Dictionary<string, int>()
            {
                { "Meryovi", 84 },
                { "Juan", 84 }
            };
            diccionarioNotas.Add("Pedro", 74);

            // Los diccionarios contienen una llave y un valor.
            // Al recorrerlos con un Foreach, podemos acceder a sus propiedades.
            foreach (var nota in diccionarioNotas)
                Console.WriteLine("Llave unica: " + nota.Key + ", valor: " + nota.Value);
        }
        
        private static void Enumerados()
        {
            Sexo miSexo = Sexo.Masculino;

            if (miSexo == Sexo.Masculino)
                Console.WriteLine("Soy hombre");
            else
                Console.WriteLine("Soy mujer");
        }

        private static void OperacionesAritmeticas()
        {
            // Operaciones aritméticas.
            int a, b, c;
            double p1, p2, p3;

            a = 7;
            b = 3;

            p1 = a;
            p2 = b;

            // Suma.
            c = a + b;
            a++; // a = a + 1;
            a += b; // a = a + b;
            Console.WriteLine(c);

            // Resta.
            c = a - b;
            a--; // a = a - 1;
            a -= b; // a = a - b;
            Console.WriteLine(c);

            // Multiplicación.
            c = a * b;
            a *= b; // a = a * b;
            Console.WriteLine(c);

            // Division.
            c = a / b;
            a /= b; // a = a / b;
            Console.WriteLine(c);

            // Modulo (restante de la division).
            c = a % b;
            Console.WriteLine(c);

            // Potencia.
            p3 = Math.Pow(p1, p2);
            Console.WriteLine(p3);

            // Raíz cuadrada.
            p3 = Math.Sqrt(9);
            Console.WriteLine(p3);

            // Redondeos.
            p3 = Math.Floor(3.5); // Hacia abajo.
            Console.WriteLine(p3);
            p3 = Math.Ceiling(3.5); // Hacia arriba.
            Console.WriteLine(p3);
            p3 = Math.Round(3.5); // Financiero. (mayor que 3.5 hacia arriba, si no hacia abajo)
            Console.WriteLine(p3);
        }
    }
}
