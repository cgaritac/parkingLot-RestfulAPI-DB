using Empleados.Models;
using Microsoft.EntityFrameworkCore;
using Parqueos.Models;
using Reportes.Models;
using Tiquetes.Models;

namespace ServiciosRESTful
{
    public partial class Contexto : DbContext
    {
        // Entidades del Modelo de Datos

        public virtual DbSet<Parqueo> Parqueos { get; set; }

        public virtual DbSet<Empleado> Empleados { get; set; }

        public virtual DbSet<Tiquete> Tiquetes { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity <Parqueo>().ToTable("Parqueo");

            modelBuilder.Entity <Empleado>().ToTable("Empleado");

            modelBuilder.Entity<Tiquete>().ToTable("Tiquete");
        }
    }
}
