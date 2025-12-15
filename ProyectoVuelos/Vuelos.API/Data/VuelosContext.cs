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

            // Relaciones con Aeropuertos
            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.Origen)
                .WithMany()
                .HasForeignKey(v => v.OrigenCodigo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.Destino)
                .WithMany()
                .HasForeignKey(v => v.DestinoCodigo)
                .OnDelete(DeleteBehavior.Restrict);

            // NUEVO: Relación Vuelo → Reservas
            modelBuilder.Entity<Vuelo>()
                .HasMany(v => v.Reservas)
                .WithOne(r => r.Vuelo)
                .HasForeignKey(r => r.VueloId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed de Aeropuertos
            modelBuilder.Entity<Aeropuerto>().HasData(
                new Aeropuerto { Codigo = "MAD", Nombre = "Adolfo Suárez", Ciudad = "Madrid" },
                new Aeropuerto { Codigo = "BCN", Nombre = "El Prat", Ciudad = "Barcelona" },
                new Aeropuerto { Codigo = "JFK", Nombre = "John F. Kennedy", Ciudad = "New York" },
                new Aeropuerto { Codigo = "LHR", Nombre = "Heathrow", Ciudad = "Londres" },
                new Aeropuerto { Codigo = "CDG", Nombre = "Charles de Gaulle", Ciudad = "París" },
                new Aeropuerto { Codigo = "DXB", Nombre = "Dubai Intl", Ciudad = "Dubai" },
                new Aeropuerto { Codigo = "HND", Nombre = "Haneda", Ciudad = "Tokio" },
                new Aeropuerto { Codigo = "SYD", Nombre = "Kingsford Smith", Ciudad = "Sydney" }
            );

            // Seed de Vuelos
            modelBuilder.Entity<Vuelo>().HasData(
                new Vuelo { Id = 1, OrigenCodigo = "MAD", DestinoCodigo = "BCN", Fecha = DateTime.Now.AddDays(1), Hora = "08:00", Precio = 55, AsientosTotales = 150, AsientosOcupados = 120, Activo = true },
                new Vuelo { Id = 2, OrigenCodigo = "BCN", DestinoCodigo = "MAD", Fecha = DateTime.Now.AddDays(1).AddHours(5), Hora = "13:00", Precio = 60, AsientosTotales = 150, AsientosOcupados = 40, Activo = true },
                new Vuelo { Id = 3, OrigenCodigo = "MAD", DestinoCodigo = "JFK", Fecha = DateTime.Now.AddDays(2), Hora = "10:30", Precio = 450, AsientosTotales = 300, AsientosOcupados = 299, Activo = true },
                new Vuelo { Id = 4, OrigenCodigo = "JFK", DestinoCodigo = "LHR", Fecha = DateTime.Now.AddDays(3), Hora = "18:00", Precio = 380, AsientosTotales = 300, AsientosOcupados = 150, Activo = true },
                new Vuelo { Id = 5, OrigenCodigo = "LHR", DestinoCodigo = "JFK", Fecha = DateTime.Now.AddDays(4), Hora = "09:15", Precio = 410, AsientosTotales = 300, AsientosOcupados = 300, Activo = true },
                new Vuelo { Id = 6, OrigenCodigo = "CDG", DestinoCodigo = "MAD", Fecha = DateTime.Now.AddDays(1), Hora = "07:45", Precio = 90, AsientosTotales = 180, AsientosOcupados = 10, Activo = true },
                new Vuelo { Id = 7, OrigenCodigo = "MAD", DestinoCodigo = "LHR", Fecha = DateTime.Now.AddDays(5), Hora = "16:20", Precio = 120, AsientosTotales = 180, AsientosOcupados = 90, Activo = true },
                new Vuelo { Id = 8, OrigenCodigo = "DXB", DestinoCodigo = "HND", Fecha = DateTime.Now.AddDays(10), Hora = "02:00", Precio = 850, AsientosTotales = 400, AsientosOcupados = 200, Activo = true },
                new Vuelo { Id = 9, OrigenCodigo = "HND", DestinoCodigo = "SYD", Fecha = DateTime.Now.AddDays(11), Hora = "22:30", Precio = 700, AsientosTotales = 350, AsientosOcupados = 50, Activo = true },
                new Vuelo { Id = 10, OrigenCodigo = "MAD", DestinoCodigo = "JFK", Fecha = DateTime.Now.AddDays(-1), Hora = "12:00", Precio = 0, AsientosTotales = 100, AsientosOcupados = 0, Activo = false }
            );
        }
    }
}
