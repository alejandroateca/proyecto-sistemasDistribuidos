using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vuelos.API.Data;
using Vuelos.Shared;

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

            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVuelo), new { id = vuelo.Id }, vuelo);
        }

        [HttpGet]
        public async Task<ActionResult<List<VueloVista>>> GetVuelos()
        {
            var vuelos = await _context.Vuelos
                .Where(v => v.Activo) // 1. Solo vuelos activos
                .Select(v => new VueloVista // 2. Convertimos a VueloVista
                {
                    Id = v.Id,
                    // Aquí sacamos el nombre de la ciudad gracias a la relación
                    Origen = v.Origen != null ? v.Origen.Ciudad : "Desconocido",
                    Destino = v.Destino != null ? v.Destino.Ciudad : "Desconocido",

                    Fecha = v.Fecha.ToShortDateString(),
                    Hora = v.Hora,
                    Precio = v.Precio,

                    // Tus datos de asientos
                    AsientosTotales = v.AsientosTotales,
                    AsientosOcupados = v.AsientosOcupados,
                    AsientosDisponibles = v.AsientosDisponibles
                })
                .ToListAsync();

            return Ok(vuelos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VueloVista>> GetVuelo(int id)
        {
            // Buscamos el vuelo que coincida con el ID y transformamos a VueloVista
            var vuelo = await _context.Vuelos
                .Where(v => v.Id == id && v.Activo) // Filtro por ID y que esté activo
                .Select(v => new VueloVista
                {
                    Id = v.Id,
                    Origen = v.Origen != null ? v.Origen.Ciudad : "Desconocido",
                    Destino = v.Destino != null ? v.Destino.Ciudad : "Desconocido",
                    Fecha = v.Fecha.ToShortDateString(),
                    Hora = v.Hora,
                    Precio = v.Precio,
                    AsientosTotales = v.AsientosTotales,
                    AsientosOcupados = v.AsientosOcupados,
                    AsientosDisponibles = v.AsientosDisponibles
                })
                .FirstOrDefaultAsync(); // Cogemos el primero (o null si no existe)

            if (vuelo == null)
            {
                return NotFound("El vuelo no existe.");
            }

            return Ok(vuelo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound();
            }

            vuelo.Activo = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}