using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios2
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta()
        {
            VelocidadMaxima = 180;
        }

        public override void Encender()
        {
            Console.WriteLine("La motocicleta encendió por medio del switch y la palanca de cambio");
        }

        public override void Conducir()
        {
            Console.WriteLine("El conductor acelero la motocicleta rápidamente hasta llegar a los {0} km/h", VelocidadMaxima);
        }
    }
}
