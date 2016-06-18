using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos un objeto de tipo conductor.
            var conductor = new Conductor();

            conductor.Nombre = "Meryovi";

            // Creamos el vehículo que sera conducido.
            var vehiculo = new Motocicleta();

            vehiculo.Marca = "Honda";
            vehiculo.Modelo = "Civic";
            vehiculo.Ano = 2010;
            vehiculo.Combustible = Combustible.Gasolina;

            // Le indicamos al conductor que conduzca el vehículo.
            conductor.Conducir(vehiculo);

            Console.ReadKey();
        }
    }
}
