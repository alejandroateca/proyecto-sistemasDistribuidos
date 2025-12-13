using System.ComponentModel.DataAnnotations;

namespace Vuelos.Shared
{
    public class Vuelo
    {
        public int Id { get; set; }

        public string OrigenId { get; set; } = string.Empty;
        public string DestinoId { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }

        public int AsientosTotales { get; set; }
        public int AsientosOcupados { get; set; }
    }
}