using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Progreso1_EstefaniHuertas.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        [Range(0, 10000)]
        public double ValorAPagar { get; set; }

        // FK
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
    }
}
