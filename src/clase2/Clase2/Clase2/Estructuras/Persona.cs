using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Estructuras
{
    public class Persona
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        protected int Edad { get; set; }

        public void Saltar()
        {
            Console.WriteLine(Nombre + " salto");
        }
    }

    public class Cliente : Persona
    {
        public void Comprar(string articulo)
        {
            Console.WriteLine(Nombre + " compro un " + articulo);
        }
    }
}
