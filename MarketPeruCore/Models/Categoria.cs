using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPeruCore.Models
{
    [Table("CATEGORIA")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
