using System.Data.Entity;
using ProyectoFacturas.Core.Modelos;

namespace ProyectoFacturas.DataAccess.EntityFramework
{
    public class FacturasDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public FacturasDbContext() :
            base("FacturasDb")
        {

        }
    }
}
