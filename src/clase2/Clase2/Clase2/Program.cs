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
            ClasesOrientadoObjetos();

            Console.ReadKey();
        }

        /// <summary>
        /// Manejo de clases, interfaces, orientación a objetos y clases estáticas
        /// </summary>
        private static void ClasesOrientadoObjetos()
        {
            // Se crea una nueva instancia de clase utilizando el operador NEW.
            // Para ver la definición de esta clase, ir al archivo Estructuras/Cliente.cs 
            // Las clases son las principales estructuras que se utilizan en C# y representan
            // un objeto o entidad del mundo real.
            // Se llama instancia a una version especifica de un objeto. Por ejemplo, la variable "cliente" mas abajo.
            var cliente = new Cliente();

            // Se asignan valores a las propiedades o atributos de una clase de la siguiente forma:
            cliente.Nombre = "Juan";
            cliente.Apellido = "Perez";

            // Las clases estáticas permiten utilizar los métodos de una clase sin necesidad de
            // crear una nueva instancia. Usualmente son utilizadas para almacenar métodos utilitarios o generales.
            // Ej.: Un método que divide una cadena en partes, leer los archivos de un folder, etc.
            InternetBanking.IniciarSesion(cliente);

            // Una clase puede contener otras clases como propiedades.
            var cuenta = new CuentaAhorro();
            cuenta.Dueno = cliente;

            // El operador IS se utiliza para determinar si una instancia es de un tipo de clase o interfaz dada.
            // En el ejemplo mas abajo, verificamos si la cuenta implementa la interfaz IProductoCatalogo.
            if (cuenta is IProductoCatalogo)
                Console.WriteLine("Implementa la interfaz IProductoCatalogo");
            else
                Console.WriteLine("No implementa la interfaz IProductoCatalogo");
            
            // El siguiente método debita el balance de una cuenta.
            // Puedes cambiar la cuenta de mas arriba a un objeto de tipo CuentaCorriente para ver como cambia
            // el funcionamiento del programa.
            // A esta mutación en el comportamiento de acuerdo al tipo se denomina Polimorfismo.
            // Ver la definición de este método en el archivo Estructuras/InternetBanking.cs para identificar como
            // se utiliza el polimorfismo.
            InternetBanking.DebitarCuenta(cuenta, 1000);
        }

        /// <summary>
        /// Uso de listas genéricas y diccionarios en C#
        /// </summary>
        private static void ListasGenericas()
        {
            // Arreglo compuesto por tres valores: 1, 2, 4
            var arreglos = new int[] { 1, 2, 4 };

            // Lista genérica que permite agregar o remover valores de forma dinámica.
            // Las listas genéricas permiten crear listas de cualquier tipo.
            var listaEnteros = new List<int>() { 1, 2, 4 };
            listaEnteros.Add(5);
            listaEnteros.Remove(2);

            // Para recorrer los valores de una lista genérica, se utiliza la
            // instrucción foreach.
            foreach (var entero in listaEnteros)
                Console.WriteLine(entero);

            // Los diccionarios permiten agrupar una llave única y un valor.
            var diccionarioNotas = new Dictionary<string, int>()
            {
                { "Meryovi", 84 },
                { "Juan", 84 }
            };
            diccionarioNotas.Add("Pedro", 74);

            // Los diccionarios contienen una llave y un valor.
            // Al recorrerlos con un Foreach, podemos acceder a sus propiedades.
            foreach (var nota in diccionarioNotas)
                Console.WriteLine("Llave única: " + nota.Key + ", valor: " + nota.Value);
        }
        
        /// <summary>
        /// Uso de valores enumerados en C#
        /// </summary>
        private static void Enumerados()
        {
            // Los enumerados permiten nombrar valores numéricos para dar
            // un mayor significado.
            // Pueden ver la definición de este enumerado en el archivo Estructuras/Sexo.cs
            Sexo miSexo = Sexo.Masculino;

            if (miSexo == Sexo.Masculino)
                Console.WriteLine("Soy hombre");
            else
                Console.WriteLine("Soy mujer");
        }

        /// <summary>
        /// Operaciones aritméticas frecuentemente utilizadas en C#
        /// </summary>
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
