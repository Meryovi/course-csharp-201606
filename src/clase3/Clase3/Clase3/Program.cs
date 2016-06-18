using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Clase3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejercicio1EnClase();

            Console.ReadKey();
        }

        private static void Ejercicio1EnClase()
        {
            // Realizar un programa que pida al usuario a través de la consola el nombre de un archivo
            // y luego su contenido. Debe crear un archivo con el nombre indicado y el contenido
            // digitado por el usuario.
            // El programa debe manejar posibles excepciones que se pudieran generar para guardar
            // el archivo.

            string rutaArchivo;
            string contenido;

            // Esta parte lee por la consola el nombre y el contenido del archivo,
            // solicitando la información a el usuario.
            Console.WriteLine("Especifique el nombre del archivo:");
            rutaArchivo = Console.ReadLine();
            rutaArchivo += ".txt";

            Console.WriteLine("Especifique el contenido del archivo:");
            contenido = Console.ReadLine();

            try
            {
                // Esta parte crea y escribe en el archivo el contenido digitado por 
                // el usuario. En caso de error lanza una excepción que es atrapada
                // mas abajo.
                File.WriteAllText(rutaArchivo, contenido);
            }
            catch (Exception)
            {
                // Esta parte captura cualquier error que se haya producido al momento
                // de crear o escribir el archivo.
                Console.WriteLine("Se produjo un error al guardar el archivo");
            }
        }

        private static void UtilitariosDeArchivos()
        {
            // Crea un archivo nuevo.
            var archivoCreado = File.Create("test1.txt");
            archivoCreado.Close();

            // Copia o duplica un archivo.
            File.Copy("test1.txt", "test2.txt");

            // Elimina un archivo.
            File.Delete("test1.txt");

            // Mueve un archivo de una ubicación a otra.
            File.Move("test2.txt", "test1.txt");

            // Elimina el archivo movido.
            File.Delete("test1.txt");

            // Verifica si un archivo existe. Retorna true si existe o false si no.
            bool archivoExiste = File.Exists("test1.txt");
        }

        private static void ManejoDeParametros()
        {
            string nombreArchivo = ConfigurationManager.AppSettings["NombreArchivo"];

            Console.WriteLine("Digite el contenido del archivo: ");
            string contenido = Console.ReadLine();

            try
            {
                File.WriteAllText(nombreArchivo, contenido);
            }
            catch (Exception)
            {
                Console.WriteLine("Lo sentimos, no fue posible guardar su información.");
            }
        }

        private static void ManejoDeExcepciones()
        {
            try
            {
                File.Create("C:\\prueba.txt");
                Console.WriteLine("Lo cree en el C");

                // Esto lanza un error personalizado de mi aplicación.
                throw new ErrorDeMiAppException();
            }
            catch (UnauthorizedAccessException)
            {
                File.Create("prueba.txt");
                Console.WriteLine("Lo cree en el directorio local");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Esta parte siempre se ejecuta");
            }
        }

        private static void LecturaArchivoLineas()
        {
            // Forma simple.
            string[] lineas = File.ReadAllLines("ejemplo.txt");

            foreach (var linea in lineas)
            {
                Console.WriteLine(linea);
            }

            Console.WriteLine(new String('-', 20));

            // De esta forma de puede leer el archivo linea por linea.
            // Se utiliza la sentencia using para garantizar que el archivo sea cerrado
            // una vez terminemos con su uso.
            using (var reader = new StreamReader("ejemplo.txt"))
            {
                /*
                do
                {
                    linea2 = reader.ReadLine();
                    Console.WriteLine(linea2);
                }
                while (linea2 != null);
                */
                string linea2;
                while ((linea2 = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea2);
                }
            }
        }

        private static void LecturaArchivosSimple()
        {
            File.WriteAllText("ejemplo.txt", "Hola mundo...");

            string contenido = File.ReadAllText("ejemplo.txt");

            Console.WriteLine(contenido);
        }

        private static void Listas()
        {
            var lista = new List<int>();

            lista.Add(12);
            lista.Add(20);

            lista.Remove(20);

            lista.Insert(0, 15);

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}
