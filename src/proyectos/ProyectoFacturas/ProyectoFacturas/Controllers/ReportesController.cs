using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFacturas.Controllers
{
    public class ReportesController : BaseController
    {
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsolidadoCliente()
        {
            var consolidado = _facturas.ReporteConsolidadoCliente();

            return View(consolidado);
        }
    }
}