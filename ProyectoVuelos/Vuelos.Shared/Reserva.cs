using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vuelos.Shared
{
    [Table("Reservas")]
    public class Reserva
    {
        public int Id { get; set; }

        public int VueloId { get; set; } 

        [ForeignKey("VueloId")]
        public Vuelo? Vuelo { get; set; }

        [Required(ErrorMessage = "El nombre del pasajero es obligatorio")]
        public string NombrePasajero { get; set; } = string.Empty;

        public DateTime FechaReserva { get; set; } = DateTime.Now;

        public int AsientosReservados { get; set; }

        public decimal ImportePagado { get; set; }

        public bool Activa { get; set; } = true;
    }
}