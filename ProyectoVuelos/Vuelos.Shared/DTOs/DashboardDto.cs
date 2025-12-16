using System.Collections.Generic;

namespace Vuelos.Shared.DTOs
{
    public class DashboardDto
    {
        public int VuelosActivos { get; set; }
        public int ReservasCanceladas { get; set; }
        public decimal DineroRecaudado { get; set; }

        public List<DatoEstadistico> TopDestinos { get; set; } = new();
        public List<DatoEstadistico> TopPasajeros { get; set; } = new();
    }

    public class DatoEstadistico
    {
        public string Etiqueta { get; set; } = string.Empty;
        public int Valor { get; set; }
    }
}