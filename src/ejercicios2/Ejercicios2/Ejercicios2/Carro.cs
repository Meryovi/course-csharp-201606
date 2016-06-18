using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios2
{
    public class Carro : Vehiculo
    {
        public Transmision Transmision { get; set; }

        public Carro()
        {
            VelocidadMaxima = 200;
        }

        public override void Encender()
        {
            Console.WriteLine("El carro se encendió por medio del mecanismo de ignición");

            if (Transmision == Transmision.Manual)
                Console.WriteLine("Al ser transmisión manual el conductor pisaba el clutch mientras encendía");
        }

        public override void Conducir()
        {
            if (Transmision == Transmision.Manual)
                Console.WriteLine("El conductor se dispone a pasar manualmente los cambios hasta llegar a {0} km/h", VelocidadMaxima);
            else if (Transmision == Transmision.Automatica)
                Console.WriteLine("El conductor acelera rápidamente hasta llegar a {0} km/h", VelocidadMaxima);
        }
    }
}
