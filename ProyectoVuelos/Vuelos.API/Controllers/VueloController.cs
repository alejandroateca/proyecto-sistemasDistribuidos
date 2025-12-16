using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vuelos.API.Data;
using Vuelos.Shared;
using Vuelos.Shared.DTOs;

namespace Vuelos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly VuelosContext _context;

        public VueloController(VuelosContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Vuelo>> CrearVuelo(Vuelo vuelo)
        {
            if (vuelo.AsientosOcupados > vuelo.AsientosTotales)
            {
                return BadRequest("Error: No puede haber más asientos ocupados que totales.");
            }

            vuelo.Activo = true;

            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVuelo), new { id = vuelo.Id }, vuelo);
        }

        [HttpGet]
        public async Task<ActionResult<List<VueloDto>>> GetVuelos()
        {
            var listaEntidades = await _context.Vuelos
                .Include(v => v.Origen)
                .Include(v => v.Destino)
                .Include(v => v.Reservas)
                .ToListAsync();

            var listaDtos = listaEntidades.Select(v => new VueloDto
            {
                Id = v.Id,
                Origen = v.Origen != null ? v.Origen.Ciudad : v.OrigenCodigo,
                Destino = v.Destino != null ? v.Destino.Ciudad : v.DestinoCodigo,
                Fecha = v.Fecha.ToShortDateString(),
                Hora = v.Hora,
                Precio = v.Precio,
                AsientosTotales = v.AsientosTotales,
                AsientosOcupados = v.AsientosOcupados,
                AsientosDisponibles = v.AsientosTotales - v.AsientosOcupados,
                Activo = v.Activo,

                CantidadReservas = v.Reservas != null ? v.Reservas.Count : 0
            }).ToList();

            return Ok(listaDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VueloDto>> GetVuelo(int id)
        {
            var v = await _context.Vuelos
                .Include(v => v.Origen)
                .Include(v => v.Destino)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (v == null)
            {
                return NotFound("El vuelo no existe.");
            }

            var vueloDto = new VueloDto
            {
                Id = v.Id,
                Origen = v.Origen != null ? v.Origen.Ciudad : v.OrigenCodigo,
                Destino = v.Destino != null ? v.Destino.Ciudad : v.DestinoCodigo,
                Fecha = v.Fecha.ToShortDateString(),
                Hora = v.Hora,
                Precio = v.Precio,
                AsientosTotales = v.AsientosTotales,
                AsientosOcupados = v.AsientosOcupados,
                AsientosDisponibles = v.AsientosTotales - v.AsientosOcupados,
                Activo = v.Activo
            };

            return Ok(vueloDto);
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardDto>> GetDashboardStats()
        {
            var stats = new DashboardDto();

            var vuelos = await _context.Vuelos
                .Include(v => v.Reservas)
                .Include(v => v.Destino)
                .ToListAsync();

            var reservas = await _context.Reservas
                .Include(r => r.Vuelo)
                .ToListAsync();

            stats.VuelosActivos = vuelos.Count(v => v.Activo);
            stats.ReservasCanceladas = reservas.Count(r => !r.Activa);


            stats.DineroRecaudado = reservas
                .Where(r => r.Activa && r.Vuelo != null)
                .Sum(r => r.AsientosReservados * (r.Vuelo?.Precio ?? 0));


            stats.TopDestinos = vuelos
                .Where(v => v.Destino != null)
                .GroupBy(v => v.Destino?.Ciudad ?? "Desconocido")
                .Select(g => new DatoEstadistico
                {
                    Etiqueta = g.Key,
                    Valor = g.SelectMany(v => v.Reservas).Where(r => r.Activa).Sum(r => r.AsientosReservados)
                })
                .Where(x => x.Valor > 0)
                .OrderByDescending(x => x.Valor)
                .Take(5)
                .ToList();

            stats.TopPasajeros = reservas
                .Where(r => r.Activa)
                .GroupBy(r => r.NombrePasajero)
                .Select(g => new DatoEstadistico
                {
                    Etiqueta = g.Key,
                    Valor = g.Sum(r => r.AsientosReservados) 
                })
                .OrderByDescending(x => x.Valor)
                .Take(5)
                .ToList();

            return Ok(stats);
        }

        [HttpPut("estado/{id}")]
        public async Task<IActionResult> ActualizarEstadoVuelo(int id, [FromQuery] bool activo)
        {
            var vuelo = await _context.Vuelos
                .Include(v => v.Reservas)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vuelo == null)
                return NotFound("Vuelo no encontrado.");

            if (vuelo.Activo == activo)
                return Ok($"El vuelo {id} ya está en estado {(activo ? "Activo" : "Cancelado")}.");

            vuelo.Activo = activo;

            if (!activo)
            {
                foreach (var reserva in vuelo.Reservas.Where(r => r.Activa))
                {
                    reserva.Activa = false;
                    vuelo.AsientosOcupados -= reserva.AsientosReservados;
                }

                if (vuelo.AsientosOcupados < 0)
                    vuelo.AsientosOcupados = 0;
            }

            await _context.SaveChangesAsync();

            return Ok($"Vuelo {id} actualizado a {(activo ? "Activo" : "Cancelado")}, reservas afectadas si aplica.");
        }

    }
}