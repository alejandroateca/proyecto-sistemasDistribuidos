using System.ComponentModel.DataAnnotations;

namespace Vuelos.Shared
{
    public class Aeropuerto
    {
        [Key]
        [StringLength(3)]
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
    }
}