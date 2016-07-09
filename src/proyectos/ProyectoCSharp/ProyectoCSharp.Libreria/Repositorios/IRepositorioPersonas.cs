using System.Collections.Generic;
using ProyectoCSharp.Libreria.Modelos;

namespace ProyectoCSharp.Libreria.Repositorios
{
    public interface IRepositorioPersonas
    {
        List<Persona> BuscarPersonas();

        bool RegistrarPersona(Persona persona);
    }
}