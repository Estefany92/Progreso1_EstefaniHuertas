using System.ComponentModel.DataAnnotations;


namespace Progreso1_EstefaniHuertas.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; } 

        public double Saldo { get; set; } 

        public bool Tipocliente { get; set; } 
        public DateTime FechaRegistro { get; set; }
                                                    
        public ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
    }
}
