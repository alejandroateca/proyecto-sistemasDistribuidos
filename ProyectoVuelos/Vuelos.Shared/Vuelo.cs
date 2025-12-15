using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vuelos.Shared
{
    [Table("Vuelos")]
    public class Vuelo
    {
        public int Id { get; set; }

        public string OrigenCodigo { get; set; } = string.Empty;

        [ForeignKey("OrigenCodigo")]
        public Aeropuerto? Origen { get; set; }

        public string DestinoCodigo { get; set; } = string.Empty;

        [ForeignKey("DestinoCodigo")]
        public Aeropuerto? Destino { get; set; }

        public DateTime Fecha { get; set; }
        public string Hora { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int AsientosTotales { get; set; }
        public int AsientosOcupados { get; set; }
        public int AsientosDisponibles => AsientosTotales - AsientosOcupados;
        public bool Activo { get; set; } = true;
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
