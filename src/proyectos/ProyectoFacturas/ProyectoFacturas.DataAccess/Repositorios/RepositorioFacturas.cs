using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFacturas.Core.Modelos;
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

        public List<Factura> BuscarTodos()
        {
            var facturas = _dbContext.Facturas
                .OrderByDescending(f => f.FechaEmision)
                .ToList();

            return facturas;
        }

        public void Registrar(Factura factura)
        {
            _dbContext.Facturas.Add(factura);
        }

        public void Editar(Factura factura)
        {
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

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
