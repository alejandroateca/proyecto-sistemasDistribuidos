using System.Collections.Generic;

namespace Vuelos.Shared
{
    public class DashboardDto
    {
        // KPIs Generales
        public int VuelosActivos { get; set; }
        public int ReservasCanceladas { get; set; }
        public decimal DineroRecaudado { get; set; } // Lo calcularemos manual

        // Listas para los gráficos
        public List<DatoEstadistico> TopDestinos { get; set; } = new();
        public List<DatoEstadistico> TopPasajeros { get; set; } = new();
    }

    public class DatoEstadistico
    {
        public string Etiqueta { get; set; } = string.Empty; // Ej: "Madrid" o "Juan"
        public int Valor { get; set; } // Cantidad de asientos
    }
}