using DavidAppCrud.Modelos;
using DavidAppCrud.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DavidAppCrud.DataAcess
{
    public class EmpleadoDbContext: DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={Conexiondb.DevolverRuta("empleado.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(col => col.idEmpleado);
                entity.Property(col => col.idEmpleado).IsRequired().ValueGeneratedOnAdd();

            });
        }
    }
}
