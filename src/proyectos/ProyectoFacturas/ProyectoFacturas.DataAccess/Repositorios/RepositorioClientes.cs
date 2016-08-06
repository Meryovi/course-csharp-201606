using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProyectoFacturas.Core.Modelos;
using ProyectoFacturas.DataAccess.EntityFramework;

namespace ProyectoFacturas.DataAccess.Repositorios
{
    public class RepositorioClientes : IDisposable
    {
        private readonly FacturasDbContext _dbContext;

        public RepositorioClientes()
        {
            _dbContext = new FacturasDbContext();
        }

        public List<Cliente> BuscarTodos()
        {
            var clientes = _dbContext.Clientes
                .OrderByDescending(c => c.FechaRegistro)
                .ToList();

            return clientes;
        }

        public Cliente BuscarPorId(string identificacion)
        {
            var cliente = _dbContext.Clientes
                .SingleOrDefault(c => c.Identificacion == identificacion);

            return cliente;
        }

        public void Registrar(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
        }

        public void Editar(Cliente cliente)
        {
            _dbContext.Clientes.Attach(cliente);
            _dbContext.Entry(cliente).State = EntityState.Modified;
        }

        public void Eliminar(Cliente cliente)
        {
            _dbContext.Clientes.Remove(cliente);
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
