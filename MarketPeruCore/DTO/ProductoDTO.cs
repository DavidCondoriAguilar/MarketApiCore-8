using System.ComponentModel.DataAnnotations;

namespace MarketPeruCore.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El IdCategoria es obligatorio.")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El IdProveedor es obligatorio.")]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(40, ErrorMessage = "El nombre del producto no puede superar los 40 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria.")]
        [StringLength(30, ErrorMessage = "La unidad de medida no puede superar los 30 caracteres.")]
        public string UnidadMedida { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio del proveedor debe ser un valor positivo.")]
        public decimal? PrecioProveedor { get; set; }

        [Required(ErrorMessage = "El stock actual es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock actual debe ser un valor positivo.")]
        public short StockActual { get; set; }

        [Required(ErrorMessage = "El stock mínimo es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo debe ser un valor positivo.")]
        public short StockMinimo { get; set; }

        [Required(ErrorMessage = "El estado de descontinuado es obligatorio.")]
        public bool Descontinuado { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }
    }
}
