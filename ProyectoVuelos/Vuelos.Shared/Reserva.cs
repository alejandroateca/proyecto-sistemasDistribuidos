namespace Vuelos.Shared
{
    public class Reserva
    {
        public int Id { get; set; }
        public int VueloId { get; set; }
        public string NombrePasajero { get; set; } = string.Empty;
        public DateTime FechaReserva { get; set; } = DateTime.Now;
        public int AsientosReservados { get; set; }
        public decimal ImportePagado { get; set; }
        public bool Activa { get; set; }
    }
}