using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vuelos.API.Data;
using Vuelos.Shared;

namespace Vuelos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase // <-- CAMBIADO A SINGULAR
    {
        private readonly VuelosContext _context;

        // El constructor debe tener el MISMO nombre que la clase
        public VueloController(VuelosContext context) // <-- CAMBIADO A SINGULAR
        {
            _context = context;
        }

        // GET: api/vuelo
        [HttpGet]
        public async Task<ActionResult<List<Vuelo>>> GetVuelos()
        {
            return await _context.Vuelos.ToListAsync();
        }

        // GET: api/vuelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelo>> GetVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound("El vuelo no existe.");
            }

            return Ok(vuelo);
        }

        // POST: api/vuelo
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

        // DELETE: api/vuelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}