using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vuelos.Shared
{
    [Table("Aeropuertos")]
    public class Aeropuerto
    {
        [Key]
        [StringLength(3)]
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
    }
}