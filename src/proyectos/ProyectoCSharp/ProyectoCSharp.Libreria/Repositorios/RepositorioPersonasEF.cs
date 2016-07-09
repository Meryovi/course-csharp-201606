using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCSharp.Libreria.EntityFramework;
using ProyectoCSharp.Libreria.Modelos;

namespace ProyectoCSharp.Libreria.Repositorios
{
    public class RepositorioPersonasEF : IRepositorioPersonas
    {
        public List<Persona> BuscarPersonas()
        {
            using (var dbContext = new PersonasDbContext())
            {
                var personas = dbContext.Personas.ToList();
                return personas;
            }
        }

        public List<Persona> BuscarEmpleados()
        {
            using (var dbContext = new PersonasDbContext())
            {
                var personas = dbContext.Personas
                    .Where(pr => pr.EsEmpleado)
                    .ToList();

                return personas;
            }
        }

        public bool RegistrarPersona(Persona persona)
        {
            using (var dbContext = new PersonasDbContext())
            {
                dbContext.Personas.Add(persona);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool EditarPersona(Persona persona)
        {
            using (var dbContext = new PersonasDbContext())
            {
                dbContext.Personas.Attach(persona);
                dbContext.SaveChanges();

                return true;
            }
        }

        public bool EliminarPersona(string identificacion)
        {
            using (var dbContext = new PersonasDbContext())
            {
                var persona = dbContext.Personas
                    .FirstOrDefault(pr => pr.Identificacion == identificacion);

                if (persona != null)
                {
                    dbContext.Personas.Remove(persona);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public Persona BuscarPersona(string identificacion)
        {
            using (var dbContext = new PersonasDbContext())
            {
                // LINQ (Language INtegrated Query)
                var persona = dbContext.Personas
                    .FirstOrDefault(pr => pr.Identificacion == identificacion);

                return persona;
            }
        }
    }
}
