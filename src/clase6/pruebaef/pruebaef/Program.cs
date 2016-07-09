using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaef
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var dbContext = new cursocsharpEntities())
            {
                var personas = dbContext.Personas.ToList();

                foreach (var persona in personas)
                {
                    Console.WriteLine(persona.Nombre);
                }
            }

            Console.ReadKey();

        }
    }
}
