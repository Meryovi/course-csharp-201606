using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProyectoCSharp.Libreria.EntityFramework;
using ProyectoCSharp.Libreria.Modelos;

namespace ProyectoCSharp.Libreria.Repositorios
{
    /// <summary>
    /// Gestiona la información de las personas en la base de datos
    /// a través de la tecnología Entity Framework
    /// </summary>
    public class RepositorioPersonasEF : IRepositorioPersonas
    {
        /// <summary>
        /// Busca las personas registradas en la base de datos
        /// </summary>
        /// <returns>Lista de personas</returns>
        public List<Persona> BuscarPersonas()
        {
            // Al utilizar los DbContext de Entity Framework,
            // siempre se debe utilizar using, o en su defecto el
            // método Dispose luego de terminar con la conexión.
            using (var dbContext = new PersonasDbContext())
            {
                // LINQ (Language INtegrated Query)

                // El método ToList() de LINQ, al usarse en EF, busca
                // todos los registros de la tabla y los devuelve como
                // una lista de objetos.
                var personas = dbContext.Personas.ToList();
                return personas;
            }
        }

        /// <summary>
        /// Busca las personas registradas en la base de datos que
        /// son empleados
        /// </summary>
        /// <returns>Lista de personas empleadas</returns>
        public List<Persona> BuscarEmpleados()
        {
            using (var dbContext = new PersonasDbContext())
            {
                // El método Where permite filtrar elementos
                // de la base de datos. Esto permite hacer búsquedas
                // y consultas mas especificas.

                // En el método Where debe especificarse una condición
                // que tenga como resultado un valor booleano (bool).

                var personas = dbContext.Personas
                    .Where(pr => pr.EsEmpleado)
                    .ToList();

                // La sintaxis que utilizamos de LINQ en este ejemplo
                // se llama Sintaxis de Método (Method Syntax).
                // Existe otra Sintaxis llamada Sintaxis de Query (Query Syntax)
                // que utiliza una nomenclatura mas parecida a SQL.

                return personas;
            }
        }

        /// <summary>
        /// Registra la información de una persona en la tabla
        /// </summary>
        /// <param name="persona">Objeto con la información de la persona</param>
        /// <returns>Valor que indica el resultado de la operación</returns>
        public bool RegistrarPersona(Persona persona)
        {
            using (var dbContext = new PersonasDbContext())
            {
                // El método Add de Entity Framework agrega un registro
                // en la tabla de la base de datos.

                // El mismo NO SURTE EFECTO hasta tanto se llama el método
                // SaveChanges. Pueden haber tantos Add como entienda y todos
                // serán ejecutados al mismo tiempo cuando se llame SaveChanges.

                dbContext.Personas.Add(persona);
                dbContext.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Edita la información de una persona
        /// </summary>
        /// <param name="persona">Objeto con la información de la persona</param>
        /// <returns>Valor que indica el estado de la operación</returns>
        public bool EditarPersona(Persona persona)
        {
            using (var dbContext = new PersonasDbContext())
            {
                // El método Attach permite enlazar un objeto existente
                // a Entity Framework; el mismo sera sincronizado con la base
                // de datos cuando se llame el método SaveChanges.
                dbContext.Personas.Attach(persona);
                dbContext.Entry(persona).State = EntityState.Modified;

                dbContext.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="identificacion">Identificación de la persona</param>
        /// <returns>Valor que indica el estado de la operación</returns>
        public bool EliminarPersona(string identificacion)
        {
            using (var dbContext = new PersonasDbContext())
            {
                // Para eliminar un registro en Entity Framework se deben seguir
                // dos pasos:

                // 1 - El primer paso es buscar el registro.
                var persona = dbContext.Personas
                    .FirstOrDefault(pr => pr.Identificacion == identificacion);

                // Si no es nulo...
                if (persona != null)
                {
                    // 2 - Luego de que tenemos el registro que se va a eliminar,
                    // utilizamos el método Remove.
                    // Al igual que los demás, Remove no surte efecto hasta tanto
                    // se llama el método SaveChanges.
                    dbContext.Personas.Remove(persona);
                    dbContext.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Busca una persona en especifico por su identificación
        /// </summary>
        /// <param name="identificacion">Identificación de la persona</param>
        /// <returns>Objeto con la información de la persona</returns>
        public Persona BuscarPersona(string identificacion)
        {
            using (var dbContext = new PersonasDbContext())
            {
                // El metodo FirstOrDefault de LINQ permite obtener
                // el primer registro que cumple con una condición dada.
                // En caso de que ningún registro cumpla con la condición,
                // el resultado es nulo.
                // El argumento de este método debe ser una condición cuyo
                // resultado sea un valor booleano. 
                var persona = dbContext.Personas
                    .FirstOrDefault(pr => pr.Identificacion == identificacion);

                return persona;
            }
        }
    }
}
