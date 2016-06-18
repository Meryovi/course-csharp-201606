using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios2
{
    public abstract class Vehiculo
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Ano { get; set; }

        public Combustible Combustible { get; set; }

        public double VelocidadMaxima { get; protected set; }

        public abstract void Encender();

        public abstract void Conducir();

        public virtual void Apagar()
        {
            Console.WriteLine("El vehículo fue estacionado y apagado");
        }
    }
}