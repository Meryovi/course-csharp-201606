using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProyectoCSharp.Libreria.Modelos;

namespace ProyectoCSharp.Libreria.Repositorios
{
    /// <summary>
    /// Gestiona la información de las personas en la base de datos
    /// a través de la tecnología ADO
    /// </summary>
    public class RepositorioPersonasADO : IRepositorioPersonas
    {
        /// <summary>
        /// Registra una nueva persona en el sistema
        /// </summary>
        /// <param name="persona">Persona a registrar</param>
        /// <returns>Valor que indica si la persona fue registrada</returns>
        public bool RegistrarPersona(Persona persona)
        {
            string conexionStr = ConfigurationManager
                .ConnectionStrings["cursocsharpdb"].ConnectionString;

            using (var conexion = new SqlConnection(conexionStr))
            {
                conexion.Open();

                // Creamos un comando, que representa una sentencia que ser.
                // ejecutada en la base de datos. En este caso el StoredProcedure
                // PersonasRegistrar.
                var comando = new SqlCommand("PersonasCrear", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                // Agregamos a los parámetros del comando cada uno de los parámetros
                // de entrada que son requeridos.
                comando.Parameters.Add(new SqlParameter("@Identificacion", persona.Identificacion));
                comando.Parameters.Add(new SqlParameter("@Nombre", persona.Nombre));
                comando.Parameters.Add(new SqlParameter("@Sexo", persona.Sexo));
                comando.Parameters.Add(new SqlParameter("@FechaNacimiento", persona.FechaNacimiento));
                comando.Parameters.Add(new SqlParameter("@EsEmpleado", persona.EsEmpleado));
                comando.Parameters.Add(new SqlParameter("@Sueldo", persona.Sueldo));

                // Ejecutamos el comando utilizando el método ExecuteNonQuery
                // que se usa para comandos que insertan, actualizan o eliminan datos
                // en la base de datos; y devuelve la cantidad de registros afectados.
                int registrosAfectados = comando.ExecuteNonQuery();

                if (registrosAfectados > 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Busca todas las personas registradas en el sistema
        /// </summary>
        /// <returns>Lista con las personas registradas</returns>
        public List<Persona> BuscarPersonas()
        {
            // Leemos la cadena de conexión del archivo de configuración de
            // la aplicación.
            string conexionStr = ConfigurationManager
                .ConnectionStrings["cursocsharpdb"].ConnectionString;

            var personas = new List<Persona>();

            using (var conexion = new SqlConnection(conexionStr))
            {
                conexion.Open();

                // Creamos un comando, que representa una sentencia que ser.
                // ejecutada en la base de datos. En este caso el StoredProcedure
                // PersonasBuscarTodas.
                var comando = new SqlCommand("PersonasBuscarTodas", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                // Para ejecutar consultas que traen información desde la base de datos
                // se utiliza el método ExecuteReader.
                var dataReader = comando.ExecuteReader();

                // Leemos cada registro retornado de la base de datos.
                while (dataReader.Read())
                {
                    var persona = new Persona();

                    persona.Identificacion = (string)dataReader["Identificacion"];
                    persona.Nombre = (string)dataReader["Nombre"];
                    persona.Sexo = (string)dataReader["Sexo"];
                    persona.EsEmpleado = (bool)dataReader["EsEmpleado"];
                    persona.FechaNacimiento = (DateTime)dataReader["FechaNacimiento"];

                    if (dataReader["Sueldo"] != DBNull.Value)
                        persona.Sueldo = Convert.ToDecimal(dataReader["Sueldo"]);

                    personas.Add(persona);
                }

                // Importante: Cerramos el DataReader.
                dataReader.Close();
            }

            return personas;
        }
    }
}
