using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCSharp.Libreria.Modelos;

namespace ProyectoCSharp.Libreria.EntityFramework
{
    public class PersonasDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public PersonasDbContext()
            : base("cursocsharpdb") { }
    }
}
