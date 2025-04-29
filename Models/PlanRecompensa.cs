using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Progreso1_EstefaniHuertas.Models
{
    public class PlanRecompensa
    {
        [Key]
        public int PlanRecompensaId { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public int PuntosAcumulados
        {
            get
            {
                int puntos = 0;
                if (Cliente != null && Cliente.Reserva != null)
                {
                    puntos = Cliente.Reserva.Count * 100;
                }
                return puntos;
            }
        }

        public string TipoRecompensa
        {
            get
            {
                string tipo = "SILVER";
                if (PuntosAcumulados >= 500)
                {
                    tipo = "GOLD";
                }
                return tipo;
            }
        }
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}
