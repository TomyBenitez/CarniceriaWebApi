using CarniceriaWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_Carnicería.Models;

namespace CarniceriaWebApi.Context
{
    public class CarniceriaDbContext : DbContext
    {
        public CarniceriaDbContext(DbContextOptions<CarniceriaDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cobrador> Cobradores { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
    }
}
