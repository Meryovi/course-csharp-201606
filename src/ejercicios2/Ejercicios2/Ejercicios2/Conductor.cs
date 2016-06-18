using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios2
{
    public class Conductor
    {
        public string Nombre { get; set; }

        public void Conducir(Vehiculo vehiculo)
        {
            Console.WriteLine(
                "{0} se dispone a encender el vehículo {1} {2}, {3}",
                Nombre,
                vehiculo.Marca,
                vehiculo.Modelo,
                vehiculo.Ano);

            vehiculo.Encender();

            vehiculo.Conducir();

            vehiculo.Apagar();
        }
    }
}
