using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoCSharp.Libreria.Repositorios;

namespace ProyectoCSharp.WebMvc.Controllers
{
    public class PersonasController : Controller
    {
        private RepositorioPersonasEF repositorioPersonas;

        public PersonasController()
        {
            repositorioPersonas = new RepositorioPersonasEF();
        }

        // GET: Personas
        public ActionResult Index()
        {
            var personas = repositorioPersonas.BuscarPersonas();

            return View(personas);
        }

        // GET: Personas/Details/5
        public ActionResult Details(string id)
        {
            var persona = repositorioPersonas.BuscarPersona(id);

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
