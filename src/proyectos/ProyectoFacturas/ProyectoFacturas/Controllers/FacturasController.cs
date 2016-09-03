using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProyectoFacturas.Core.Modelos;
using ProyectoFacturas.DataAccess.Repositorios;

namespace ProyectoFacturas.Controllers
{
    public class FacturasController : BaseController
    {
        // GET: Facturas
        public ActionResult Index(string q)
        {
            List<Factura> facturas;

            if (string.IsNullOrEmpty(q))
                facturas = _facturas.BuscarTodos();
            else
                facturas = _facturas.BuscarPorNombreCliente(q);

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

            CargarListasCreateEdit();

            return View(factura);
        }

        // POST: Facturas/Create
        [HttpPost]
        public ActionResult Create(Factura factura)
        {
            try
            {
                if (!_clientes.ValidarClienteExiste(factura.Identificacion))
                    ModelState.AddModelError("Identificacion",
                        "No existe un cliente con la identificación especificada");

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

            CargarListasCreateEdit();

            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            var factura = _facturas.BuscarPorId(id);

            if (factura == null)
                return RedirectToAction("Index");

            CargarListasCreateEdit();

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

            CargarListasCreateEdit();

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

        private void CargarListasCreateEdit()
        {
            ViewBag.Identificacion = _clientes.BuscarTodos()
                .Select(c => new SelectListItem()
                {
                    Value = c.Identificacion,
                    Text = c.Nombre
                });
        }
    }
}
