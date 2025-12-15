namespace Vuelos.Shared
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public string NombrePasajero { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string FechaVuelo { get; set; } = string.Empty;
        public int AsientosReservados { get; set; }
        public decimal ImportePagado { get; set; }
        public bool Activa { get; set; }
        public string FechaReserva { get; set; } = string.Empty;
    }
}