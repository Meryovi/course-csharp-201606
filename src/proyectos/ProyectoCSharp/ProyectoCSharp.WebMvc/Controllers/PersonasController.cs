using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCSharp.Libreria.Modelos;
using ProyectoCSharp.Libreria.Repositorios;

namespace ProyectoCSharp.WebMvc.Controllers
{
    /// <summary>
    /// Controlador de personas.
    /// En este colocaremos nuestra lógica para gestionar la información
    /// de las personas registradas en nuestro sistema.
    /// </summary>
    public class PersonasController : Controller
    {
        /// <summary>
        /// Instancia del repositorio de personas que creamos antes.
        /// Podemos reutilizar las clases creadas en el proyecto WinForms.
        /// </summary>
        private RepositorioPersonasEF repositorioPersonas;

        public PersonasController()
        {
            // Inicializamos el objeto.
            repositorioPersonas = new RepositorioPersonasEF();
        }

        // GET: Personas
        public ActionResult Index()
        {
            // Buscamos las personas registradas.
            var personas = repositorioPersonas
                .BuscarPersonas()
                .OrderByDescending(persona => persona.Sueldo.GetValueOrDefault());

            // Y las cargamos en la vista.
            return View(personas);
        }

        // GET: Personas/Details/5
        public ActionResult Details(string id)
        {
            //  Buscamos una persona en especifico.
            var persona = repositorioPersonas.BuscarPersona(id);

            // Y la cargamos en la vista.
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            var persona = new Persona();

            persona.EsEmpleado = true;
            persona.FechaNacimiento = DateTime.Now;

            return View(persona);
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                // Si la información recibida desde la vista es correcta,
                // (ModelState.IsValid), entonces registra la persona.
                repositorioPersonas.RegistrarPersona(persona);

                // Luego de registrar a la persona, envía al usuario hacia la vista
                // Index (listado de personas registradas).
                return RedirectToAction("Index");
            }

            // En caso de que la información recibida no fuera valida, carga
            // nuevamente la vista con la información recibida.
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(string id)
        {
            var persona = repositorioPersonas.BuscarPersona(id);
            
            return View(persona);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Persona persona)
        {
            if (ModelState.IsValid)
            {
                repositorioPersonas.EditarPersona(persona);

                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(string id)
        {
            repositorioPersonas.EliminarPersona(id);

            return RedirectToAction("Index");
        }
    }
}
