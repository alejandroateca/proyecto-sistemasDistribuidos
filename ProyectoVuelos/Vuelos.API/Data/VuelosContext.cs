using Microsoft.EntityFrameworkCore;
using Vuelos.Shared;
namespace Vuelos.API.Data
{
    public class VuelosContext : DbContext
    {
        public VuelosContext(DbContextOptions<VuelosContext> options) : base(options) { }

        public DbSet<Aeropuerto> Aeropuertos { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aeropuertos
            modelBuilder.Entity<Aeropuerto>().HasData(
                new Aeropuerto { Codigo = "MAD", Nombre = "Barajas", Ciudad = "Madrid" },
                new Aeropuerto { Codigo = "BCN", Nombre = "El Prat", Ciudad = "Barcelona" },
                new Aeropuerto { Codigo = "JFK", Nombre = "JFK Intl", Ciudad = "New York" }
            );

            // (Datos falsos para la demo)
            modelBuilder.Entity<Vuelo>().HasData(
                new Vuelo { Id = 1, Origen = "MAD", Destino = "BCN", Fecha = DateTime.Now.AddDays(1), Precio = 50, AsientosTotales = 100, AsientosOcupados = 10 },
                new Vuelo { Id = 2, Origen = "MAD", Destino = "JFK", Fecha = DateTime.Now.AddDays(2), Precio = 450, AsientosTotales = 200, AsientosOcupados = 199 }
            );
        }
    }
}