using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vuelos.API.Data;
using Vuelos.Shared;

namespace Vuelos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly VuelosContext _context;

        public ReservaController(VuelosContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> CrearReserva(Reserva reserva)
        {
            var vuelo = await _context.Vuelos.FindAsync(reserva.VueloId);

            if (vuelo == null)
            {
                return NotFound("El vuelo indicado no existe.");
            }

            // Validamos disponibilidad
            if (vuelo.AsientosDisponibles < reserva.AsientosReservados)
            {
                return BadRequest($"No hay suficientes asientos. Solo quedan {vuelo.AsientosDisponibles}.");
            }

            // Restamos asientos
            vuelo.AsientosOcupados += reserva.AsientosReservados;

            // Completamos datos de reserva
            reserva.ImportePagado = vuelo.Precio * reserva.AsientosReservados;
            reserva.FechaReserva = DateTime.Now;
            reserva.Activa = true;

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return Ok(reserva);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaDto>>> GetReservas()
        {
            // PASO 1: Traer datos "crudos" de la BD a la Memoria
            var reservasEntidad = await _context.Reservas
                .Include(r => r.Vuelo).ThenInclude(v => v.Origen)
                .Include(r => r.Vuelo).ThenInclude(v => v.Destino)
                .Where(r => r.Activa)
                .ToListAsync(); // <--- AQUÍ SE EJECUTA EL SQL

            // PASO 2: Convertir a DTO en memoria (Aquí sí funciona ToShortDateString)
            var reservasDto = reservasEntidad.Select(r => new ReservaDto
            {
                Id = r.Id,
                NombrePasajero = r.NombrePasajero,
                // Mapeo seguro con ?
                Origen = r.Vuelo != null && r.Vuelo.Origen != null ? r.Vuelo.Origen.Ciudad : "Desconocido",
                Destino = r.Vuelo != null && r.Vuelo.Destino != null ? r.Vuelo.Destino.Ciudad : "Desconocido",

                FechaVuelo = r.Vuelo != null ? r.Vuelo.Fecha.ToShortDateString() : "N/A", // C# Puro

                AsientosReservados = r.AsientosReservados,
                ImportePagado = r.ImportePagado,
                Activa = r.Activa,

                FechaReserva = r.FechaReserva.ToShortDateString() // C# Puro
            }).ToList();

            return Ok(reservasDto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> GetReserva(int id)
        {
            // PASO 1: Buscar en BD
            var r = await _context.Reservas
                .Include(r => r.Vuelo).ThenInclude(v => v.Origen)
                .Include(r => r.Vuelo).ThenInclude(v => v.Destino)
                .FirstOrDefaultAsync(x => x.Id == id); // SQL Puro

            if (r == null)
            {
                return NotFound("La reserva no existe.");
            }

            // PASO 2: Convertir a DTO manualmente
            var reservaDto = new ReservaDto
            {
                Id = r.Id,
                NombrePasajero = r.NombrePasajero,
                Origen = r.Vuelo != null && r.Vuelo.Origen != null ? r.Vuelo.Origen.Ciudad : "Desconocido",
                Destino = r.Vuelo != null && r.Vuelo.Destino != null ? r.Vuelo.Destino.Ciudad : "Desconocido",

                FechaVuelo = r.Vuelo != null ? r.Vuelo.Fecha.ToShortDateString() : "N/A",

                AsientosReservados = r.AsientosReservados,
                ImportePagado = r.ImportePagado,
                Activa = r.Activa,

                FechaReserva = r.FechaReserva.ToShortDateString()
            };

            return Ok(reservaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarReserva(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Vuelo)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null) return NotFound("Reserva no encontrada.");
            if (!reserva.Activa) return BadRequest("Ya estaba cancelada.");

            // Devolvemos los asientos al vuelo
            if (reserva.Vuelo != null)
            {
                reserva.Vuelo.AsientosOcupados -= reserva.AsientosReservados;
                if (reserva.Vuelo.AsientosOcupados < 0) reserva.Vuelo.AsientosOcupados = 0;
            }

            reserva.Activa = false;
            await _context.SaveChangesAsync();

            return Ok($"Reserva {id} cancelada. Asientos liberados.");
        }
    }
}