using MarketPeruCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPeruCore.Models
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        [Required]
        [ForeignKey("Proveedor")]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [StringLength(30)]
        public string UnidadMedida { get; set; }

        [Column(TypeName = "money")]
        public decimal? PrecioProveedor { get; set; }

        public short StockActual { get; set; }
        public short StockMinimo { get; set; }
        public bool Descontinuado { get; set; }
        public bool Estado { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
