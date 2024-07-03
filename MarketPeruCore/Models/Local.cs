using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPeruCore.Models
{
    [Table("LOCAL")]
    public class Local
    {
        [Key]
        public int IdLocal { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Distrito { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(15)]
        public string Fax { get; set; }

        public virtual ICollection<Guia> Guias { get; set; }
    }
}
