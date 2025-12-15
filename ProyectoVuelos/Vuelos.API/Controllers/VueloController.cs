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

        // POST: api/Vuelo
        [HttpPost]
        public async Task<ActionResult<Vuelo>> CrearVuelo(Vuelo vuelo)
        {
            if (vuelo.AsientosOcupados > vuelo.AsientosTotales)
            {
                return BadRequest("Error: No puede haber más asientos ocupados que totales.");
            }

            // Aseguramos que se guarde como activo por defecto
            vuelo.Activo = true;

            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVuelo), new { id = vuelo.Id }, vuelo);
        }

        // GET: api/Vuelo
        [HttpGet]
        public async Task<ActionResult<List<VueloDto>>> GetVuelos()
        {
            // PASO 1: Consulta SQL (Traemos los datos crudos a la memoria)
            var listaEntidades = await _context.Vuelos
                .Include(v => v.Origen)
                .Include(v => v.Destino)
                // ✅ CORRECCIÓN CLAVE: Quitamos el .Where(v => v.Activo) para devolver TODOS los vuelos.
                .ToListAsync();

            // PASO 2: Conversión a DTO (En memoria C#)
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
                Activo = v.Activo
            }).ToList();

            return Ok(listaDtos);
        }

        // GET: api/Vuelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VueloDto>> GetVuelo(int id)
        {
            // PASO 1: Buscamos el vuelo en BD
            var v = await _context.Vuelos
                .Include(v => v.Origen)
                .Include(v => v.Destino)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (v == null)
            {
                return NotFound("El vuelo no existe.");
            }

            // PASO 2: Convertimos a DTO manualmente
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

        // 🟢 NUEVA ACCIÓN: PUT para Cancelar (Activo = false) o Reactivar (Activo = true)
        // Usada por el método GestionarVuelo del cliente.
        [HttpPut("estado/{id}")]
        public async Task<IActionResult> ActualizarEstadoVuelo(int id, [FromQuery] bool activo)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound("Vuelo no encontrado.");
            }

            // Si ya está en el estado deseado, lo notificamos pero no es un error crítico.
            if (vuelo.Activo == activo)
            {
                return Ok($"El vuelo {id} ya está en estado {(activo ? "Activo" : "Cancelado")}.");
            }

            vuelo.Activo = activo;
            await _context.SaveChangesAsync();

            return Ok($"Vuelo {id} actualizado a {(activo ? "Activo" : "Cancelado")}.");
        }


        // DELETE: api/Vuelo/5 (Borrado Lógico Antiguo)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound();
            }

            // 🟢 Borrado Lógico: Solo desactivamos.
            vuelo.Activo = false;

            await _context.SaveChangesAsync();

            // Nota: Este método ya no es usado directamente por el botón de Cancelar del cliente,
            // pero lo dejamos funcional como borrado lógico, aunque el cliente usa la nueva acción PUT.
            return NoContent();
        }
    }
}