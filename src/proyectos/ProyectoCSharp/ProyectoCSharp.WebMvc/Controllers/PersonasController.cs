using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var personas = repositorioPersonas.BuscarPersonas();

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
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
