using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFacturas.Core.Modelos;
using ProyectoFacturas.Core.Utils;
using ProyectoFacturas.DataAccess.EntityFramework;

namespace ProyectoFacturas.DataAccess.Repositorios
{
    public class RepositorioFacturas : IDisposable
    {
        private readonly FacturasDbContext _dbContext;

        public RepositorioFacturas()
        {
            _dbContext = new FacturasDbContext();
        }

        public Factura BuscarPorId(int id)
        {
            var factura = _dbContext.Facturas
                .SingleOrDefault(f => f.Id == id);

            return factura;
        }

        public List<Factura> BuscarPorNombreCliente(string nombreIdentificacion)
        {
            List<Factura> facturas;

            if (ClientesUtils.EsCedulaValida(nombreIdentificacion))
            {
                facturas = _dbContext.Facturas
                    .Where(f => f.Identificacion == nombreIdentificacion)
                    .ToList();
            }
            else
            {
                facturas = _dbContext.Facturas
                    .Where(f => f.Cliente.Nombre.Contains(nombreIdentificacion))
                    .ToList();
            }

            return facturas;
        }

        public List<Factura> BuscarTodos()
        {
            var facturas = _dbContext.Facturas
                .OrderByDescending(f => f.FechaEmision)
                .ToList();

            return facturas;
        }

        public void Registrar(Factura factura)
        {
            ValidarFactura(factura);

            _dbContext.Facturas.Add(factura);
        }

        public void Editar(Factura factura)
        {
            ValidarFactura(factura);

            _dbContext.Facturas.Attach(factura);
            _dbContext.Entry(factura).State = EntityState.Modified;
        }

        public void Eliminar(Factura factura)
        {
            _dbContext.Facturas.Remove(factura);
        }

        public bool GuardarCambios()
        {
            int registros = _dbContext.SaveChanges();

            return registros > 0;
        }

        public IEnumerable<IGrouping<Cliente, Factura>>
            ReporteConsolidadoCliente()
        {
            var consolidado = _dbContext.Facturas
                .Include("Cliente") // Esto permite incluir el cliente en la consulta.
                .OrderBy(f => f.Cliente.Identificacion)
                .GroupBy(f => f.Cliente);

            return consolidado;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        private void ValidarFactura(Factura factura)
        {

            // Validar si el cliente existe.

            // Validar que si es exenta de impuesto no tenga impuesto.

        }
    }
}
