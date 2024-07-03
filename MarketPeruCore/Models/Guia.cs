using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPeruCore.Models
{
    [Table("GUIA")]
    public class Guia
    {
        [Key]
        public int IdGuia { get; set; }

        [Required]
        [ForeignKey("Local")]
        public int IdLocal { get; set; }

        public DateTime FechaSalida { get; set; }

        [StringLength(100)]
        public string Transportista { get; set; }

        public virtual Local Local { get; set; }
    }
}
