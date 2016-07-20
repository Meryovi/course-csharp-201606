using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webApp.Models
{
    /// <summary>
    /// Esta clase representa un modelo del sistema.
    /// Los modelos componen las entidades de negocio que se gestionaran
    /// en el sistema.
    /// </summary>
    public class Persona
    {
        // Se utilizan atributos para agregar reglas de validación
        // al modelo.
        // El atributo Required causa que una propiedad sea requerida.
        // El atributo StringLength valida la longitud máxima de una cadena.
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }
    }
}