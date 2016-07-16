using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApp.Models;

namespace webApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var persona = new Persona()
            {
                Nombre = "Juan",
                Apellido = "Perez"
            };


            ViewBag.Persona = persona;

            return View(persona);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            var persona = new Persona();

            return View(persona);
        }

        [HttpPost]
        public ActionResult Registrar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Mensaje = "La información fue digitada correctamente.";
            }

            return View(persona);
        }
    }
}