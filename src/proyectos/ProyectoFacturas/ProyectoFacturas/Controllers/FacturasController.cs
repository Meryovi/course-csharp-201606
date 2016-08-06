using System;
using System.Web.Mvc;
using ProyectoFacturas.Core.Modelos;
using ProyectoFacturas.DataAccess.Repositorios;

namespace ProyectoFacturas.Controllers
{
    public class FacturasController : Controller
    {
        private readonly RepositorioFacturas _facturas;

        public FacturasController()
        {
            _facturas = new RepositorioFacturas();
        }

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = _facturas.BuscarTodos();

            return View(facturas);
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            var factura = _facturas.BuscarPorId(id);

            if (factura == null)
                return RedirectToAction("Index");

            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create(string cliente)
        {
            var factura = new Factura();

            factura.Identificacion = cliente;
            factura.ExentaImpuesto = false;
            factura.FechaEmision = DateTime.Now;

            return View(factura);
        }

        // POST: Facturas/Create
        [HttpPost]
        public ActionResult Create(Factura factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _facturas.Registrar(factura);
                    _facturas.GuardarCambios();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            var factura = _facturas.BuscarPorId(id);

            if (factura == null)
                return RedirectToAction("Index");

            return View(factura);
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Factura factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    factura.Id = id;

                    _facturas.Editar(factura);
                    _facturas.GuardarCambios();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            var factura = _facturas.BuscarPorId(id);

            if (factura != null)
            {
                _facturas.Eliminar(factura);
                _facturas.GuardarCambios();
            }
            
            return RedirectToAction("Index");
        }
    }
}
