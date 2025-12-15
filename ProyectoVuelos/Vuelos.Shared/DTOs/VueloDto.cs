using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Shared
{
    public class VueloDto
    {
        public int Id { get; set; }

        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int AsientosTotales { get; set; }
        public int AsientosOcupados { get; set; }
        public int AsientosDisponibles { get; set; }
        public bool Activo {  get; set; }
        public int CantidadReservas { get; set; }
    }
}