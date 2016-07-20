using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApp.Models;

namespace webApp.Controllers
{
    /// <summary>
    /// El controlador gestiona las peticiones de los usuarios, interactua
    /// con los modelos y solicita la generación de las vistas.
    /// También se encarga de generar las rutas de acceso, las cuales se generan
    /// con el nombre del controlador / nombre de la acción (método).
    /// Ej.: La ruta de la acción Registrar seria [ruta de la app]/Home/Registrar
    /// </summary>
    public class HomeController : Controller
    {
        //
        // GET: Home
        public ActionResult Index()
        {
            // En esta vista generamos la información de una persona
            // y la pasamos a la vista para mostrarla.
            var persona = new Persona()
            {
                Nombre = "Juan",
                Apellido = "Perez"
            };
            
            // Podemos enviar información a la vista a través de ViewBag.
            // Tiene la desventaja de que no ofrece auto-completado.
            // Se utiliza usualmente para pasar datos simples a la vista, como
            // mensajes.
            ViewBag.Persona = persona;

            // Las acciones usualmente terminan con la linea "return View" o derivada.
            // Esto quiere decir que la acción cargara la vista.
            // Se puede pasar un objeto como parámetro a la vista, pero esta
            // debe esperarlo como parámetro. 
            return View(persona);
        }

        // El atributo HttpGet se utiliza para las acciones que serán accedidas
        // a través del método GET. Usualmente a través de un link u opción de la aplicación.
        // En este caso, se utiliza para cargar el formulario de registro.
        [HttpGet]
        public ActionResult Registrar()
        {
            // Esta acción creara una nueva persona y la enviara a la vista
            // sin ninguna información.
            var persona = new Persona();

            return View(persona);
        }

        // El atributo HttpPost se utiliza para acciones que reciben información
        // digitada por el usuario en un paso previo, usualmente en un formulario.
        // En este caso, se utiliza para capturar los datos completados en el
        // formulario de registro.
        [HttpPost]
        public ActionResult Registrar(Persona persona)
        {
            // La propiedad ModelState.IsValid es true cuando todos los datos
            // registrados en el modelo (en este caso la Persona que se recibe como parámetro)
            // cumple con todas las reglas de validación establecidas.
            // Las reglas de validación son los atributos colocados en la clase Persona (Required y StringLength en este caso).
            if (ModelState.IsValid)
            {
                ViewBag.Mensaje = "La información fue digitada correctamente.";
            }

            return View(persona);
        }
    }
}