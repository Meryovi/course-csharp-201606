using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFacturas.DataAccess.Repositorios;

namespace ProyectoFacturas.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly RepositorioFacturas _facturas;

        protected readonly RepositorioClientes _clientes;
        
        public BaseController()
        {
            _facturas = new RepositorioFacturas();
            _clientes = new RepositorioClientes();
        }

        protected override void Dispose(bool disposing)
        {
            _facturas.Dispose();
            _clientes.Dispose();

            base.Dispose(disposing);
        }
    }
}