using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vuelos.Shared
{
    [Table("Vuelos")]
    public class Vuelo
    {
        public int Id { get; set; }

        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public string Hora { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int AsientosTotales { get; set; }
        public int AsientosOcupados { get; set; }

        public int AsientosDisponibles => AsientosTotales - AsientosOcupados;
    }
}