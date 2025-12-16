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

            if (vuelo == null) return NotFound("El vuelo indicado no existe.");

            if (vuelo.AsientosDisponibles < reserva.AsientosReservados)
                return BadRequest($"No hay suficientes asientos. Solo quedan {vuelo.AsientosDisponibles}.");

            vuelo.AsientosOcupados += reserva.AsientosReservados;
            reserva.ImportePagado = vuelo.Precio * reserva.AsientosReservados;
            reserva.FechaReserva = DateTime.Now;
            reserva.Activa = true;

            reserva.Vuelo = null;

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaDto>>> GetReservas()
        {

            var reservasEntidad = await _context.Reservas
                .Include(r => r.Vuelo)
                .ThenInclude(v => v!.Origen)
                .Include(r => r.Vuelo)
                .ThenInclude(v => v!.Destino)
                .AsNoTracking()
                .ToListAsync();

            var reservasDto = reservasEntidad.Select(r => new ReservaDto
            {
                Id = r.Id,
                NombrePasajero = r.NombrePasajero,

                Origen = r.Vuelo?.Origen?.Ciudad ?? "Vuelo Cancelado",
                Destino = r.Vuelo?.Destino?.Ciudad ?? "Vuelo Cancelado",

                FechaReserva = r.FechaReserva.ToShortDateString(),
                FechaVuelo = r.Vuelo?.Fecha.ToShortDateString() ?? "N/A",

                AsientosReservados = r.AsientosReservados,
                ImportePagado = r.ImportePagado,
                Activa = r.Activa,
            }).ToList();

            return Ok(reservasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> GetReserva(int id)
        {
            var r = await _context.Reservas
                .Include(r => r.Vuelo).ThenInclude(v => v!.Origen)
                .Include(r => r.Vuelo).ThenInclude(v => v!.Destino)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (r == null)
            {
                return NotFound("La reserva no existe.");
            }

            var reservaDto = new ReservaDto
            {
                Id = r.Id,
                NombrePasajero = r.NombrePasajero,
                Origen = r.Vuelo?.Origen?.Ciudad ?? "Vuelo Cancelado",
                Destino = r.Vuelo?.Destino?.Ciudad ?? "Vuelo Cancelado",
                FechaVuelo = r.Vuelo?.Fecha.ToShortDateString() ?? "N/A",
                FechaReserva = r.FechaReserva.ToShortDateString(),
                AsientosReservados = r.AsientosReservados,
                ImportePagado = r.ImportePagado,
                Activa = r.Activa,
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