using System.ComponentModel.DataAnnotations;

namespace MarketPeruCore.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255, ErrorMessage = "La descripción no puede superar los 255 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }
    }
}
