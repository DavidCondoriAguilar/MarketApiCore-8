using MarketPeruCore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPeruCore.Models
{
    [Table("PROVEEDOR")]
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [StringLength(30)]
        public string Representante { get; set; }

        [StringLength(60)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public string Ciudad { get; set; }

        [StringLength(15)]
        public string Departamento { get; set; }

        [StringLength(15)]
        public string CodigoPostal { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(15)]
        public string Fax { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
