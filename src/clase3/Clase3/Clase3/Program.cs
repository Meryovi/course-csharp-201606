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
            // La clase File tiene multiples métodos que nos pueden ayudar a realizar
            // actividades relacionadas al manejo de archivo con mucha facilidad:

            // Crea un archivo nuevo.
            var archivoCreado = File.Create("test1.txt");
            archivoCreado.Close();

            // Copia o duplica un archivo.
            File.Copy("test1.txt", "test2.txt");

            // Elimina un archivo de la PC.
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
            // C# nos permite manejar parámetros en nuestras aplicaciones y leerlos
            // de forma sencilla.

            // Los parámetros son registrados en el archivo App.Config de la aplicación.
            // La clase ConfigurationManager nos permite acceder a estos parámetros.

            // Los parámetros son importantes porque nos permiten leer configuraciones
            // de la aplicación que pueden variar de acuerdo al equipo o entorno en el cual
            // se encuentra la aplicación.
            // En lo adelante, prestaremos mucha atención a los parámetros en nuestras
            // aplicaciones.
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
            // Las Excepciones se utilizan para romper el flujo de ejecución natural de la aplicación,
            // usualmente cuando se encuentran situaciones inesperadas.
            // El fragmento de código inmediatamente próximo luego de una excepción no se ejecuta.

            // Los bloques try...catch nos permiten tomar decisiones en caso de producirse
            // Excepción en nuestro código.

            try
            {
                // Esta linea lanzara una Excepción porque el directorio C:\ es reservado.
                File.Create("C:\\prueba.txt");

                // Esta linea nunca sera ejecutada debido a que la linea anterior produjo
                // una Excepción.
                Console.WriteLine("Lo cree en el C");
            }
            catch (UnauthorizedAccessException)
            {
                // La linea anterior lanzo un Excepción de tipo UnauthorizedAccess (acceso no autorizado)
                // por lo cual se ejecutara este fragmento de código.
                File.Create("prueba.txt");
                Console.WriteLine("Lo cree en el directorio local");
            }
            catch (Exception ex)
            {
                // En caso de que no haya una sentencia catch con el tipo de Excepción que se produjo,
                // se invocara el bloque que solo tenga el tipo "Exception".
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // El bloque finally siempre es ejecutado se haya producido o no
                // una Excepción dentro del bloque try.
                Console.WriteLine("Esta parte siempre se ejecuta");
            }
        }

        private static void LecturaArchivoLineas()
        {
            // Si queremos leer un archivo completo por lineas (muy útil por ejemplo
            // si almacenamos en este archivo una lista de objetos o cadenas), tenemos
            // varias opciones.

            // Forma simple. Utilizando el método ReadAllLines.
            // Devuelve un arreglo (forma básica de Lista) con todas las lineas.
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
            // En C# el manejo de archivos es un proceso simple.

            // Para crear un archivo ejemplo.txt con el contenido Hola mundo...
            // podemos utilizar el método WriteAllText de la clase File.
            // La clase file esta contenida en la librería System.IO
            File.WriteAllText("ejemplo.txt", "Hola mundo...");

            // Para leer el contenido del archivo ejemplo.txt, utilizamos el método
            // ReadAllText.
            string contenido = File.ReadAllText("ejemplo.txt");

            Console.WriteLine(contenido);
        }

        private static void Listas()
        {
            // Para crear una lista dinámica, se utiliza la clase List.
            // Debe especificarse entre signos de mayor y menor <> el tipo de datos que se almacenara
            // en la lista. Las listas pueden almacenar objetos de cualquier tipo de dato.
            var lista = new List<int>();

            // Para agregar valores en la lista, se utiliza el método Add.
            // El método Add siempre agrega los valores nuevos al final de la lista.
            lista.Add(12);
            lista.Add(20);

            // Para remover un valor especifico, se utiliza el método Remove.
            lista.Remove(20);

            // Para insertar un valor en una posición especifica dentro de la lista,
            // se utiliza el método Insert. La posición 0 es la primera dentro de la lista.
            lista.Insert(0, 15);

            // Para remover un valor en una posición especifica dentro de la lista,
            // se utiliza el método RemoveAt.
            lista.RemoveAt(0);

            // Para iterar sobre todos los elementos de la lista se utiliza la sentencia
            // foreach. En el ejemplo mas abajo, el valor de cada elemento estará en la variable
            // elemento.
            foreach (int elemento in lista)
            {
                Console.WriteLine(elemento);
            }
        }
    }
}
