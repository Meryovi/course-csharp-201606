using System;
using System.Text.RegularExpressions;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Una expresión regular es una expresión de texto que permite identificar, remplazar y manipular
            // patrones en cadenas de texto.

            // Son muy útiles en el desarrollo de aplicaciones ya que permiten crear de forma sencilla
            // funcionalidades que de otra forma serian muy complejas de implementar.

            // Información sobre las expresiones regulares.
            // https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions

            string cadena   = "Mi nombre es Meryovi, cédula 22300100101";
            string cedula   = "22300100101";
            string placa    = "A332032";

            // Caracteres especiales de las expresiones regulares:

            // ^ quiere decir el inicio de la cadena
            // $ quiere decir el final de la cadena
            // [] contienen el conjunto de caracteres a permitir
            // {} indica la cantidad de caracteres
            // () crea un grupo que puede ser utilizado mas adelante
            // - permite especificar un rango de caracteres (ej.: del cero al nueve, 0-9)
            // . quiere decir cualquier caracter
            // + quiere decir que el caracter antes de este símbolo se puede repetir 1 o mas veces
            // ? quiere decir que el caracter antes de este símbolo puede estar una vez o no estar
            // \\ se usa para utilizar en la expresión regular cualquier caracter reservado

            // Las expresiones regulares se pueden utilizar para verificar si una cadena
            // cumple con un formato definido.
            Console.WriteLine("Expresión regular para verificar la cédula:");

            // Verifica si la cadena ES una secuencia de 11 caracteres numéricos.
            Console.WriteLine(Regex.IsMatch(cedula, "^[0-9]{11}$"));
            // Verifica si la cadena ES una cédula (###-#######-#, puede no tener guiones)
            Console.WriteLine(Regex.IsMatch(cedula, "^[0-9]{3}\\-?[0-9]{7}\\-?[0-9]{1}$"));
            Console.WriteLine(Regex.IsMatch(cadena, "^[0-9]{3}\\-?[0-9]{7}\\-?[0-9]{1}$"));
            // Verifica si la cadena CONTIENE una cédula (ver que no se uso ^ ni $)
            Console.WriteLine(Regex.IsMatch(cadena, "[0-9]{3}\\-?[0-9]{7}\\-?[0-9]{1}"));
            
            Console.WriteLine("Expresión regular para verificar una placa de vehículo:");

            // Verifica si la cadena tiene 7 caracteres alfanuméricos o numéricos.
            Console.WriteLine(Regex.IsMatch(placa, "^[0-9A-Z]{7}$"));
            // Verifica si la cadena tiene un caracter alfanumérico seguido de 6 numéricos.
            Console.WriteLine(Regex.IsMatch(placa, "^[A-Z][0-9]{6}$"));
            // Verifica si la cadena es una placa de RD. Ej.: A123123.
            Console.WriteLine(Regex.IsMatch(placa, "^[AGLZE][0-9]{6}$"));

            Console.WriteLine();

            // Las expresiones regulares también se pueden utilizar para remplazar patrones
            // dentro de una cadena.
            Console.WriteLine("Expresión regular para remplazar cadenas:");

            // Remplaza una secuencia de 11 caracteres numéricos por 6 asteriscos.
            Console.WriteLine(Regex.Replace(cadena, "[0-9]{11}", "******"));
            // Busca 3 números y crea un grupo con ellos ($1), luego 7 números
            // y luego 1 número y crea un ultimo grupo ($2).
            // Remplaza esa cadena por los tres primeros caracteres, 7 asteriscos y el ultimo caracter.
            Console.WriteLine(Regex.Replace(cadena, "([0-9]{3})[0-9]{7}([0-1])", "$1*******$2"));
            // Busca el la cadena un grupo e caracteres alfanuméricos luego de "Mi nombre es "
            // y guarda la coincidencia en el grupo 1.
            // Utilizamos en C# ese grupo para imprimir el nombre.
            Console.WriteLine("Tu nombre es " +
                Regex.Match(cadena, "Mi nombre es ([A-Za-z]+)").Groups[1].Value);

            Console.ReadKey();
        }
    }
}
