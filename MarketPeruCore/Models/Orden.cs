using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPeruCore.Models
{
    [Table("ORDEN")]
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }

        public DateTime FechaOrden { get; set; }

        public DateTime FechaEntrada { get; set; }

        public bool Estado { get; set; }
    }
}
