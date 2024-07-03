using System.ComponentModel.DataAnnotations;

namespace MarketPeruCore.DTO
{
    public class LocalDTO
    {
        public int IdLocal { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El distrito es obligatorio.")]
        [StringLength(50, ErrorMessage = "El distrito no puede superar los 50 caracteres.")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        public string Telefono { get; set; }

        [StringLength(15, ErrorMessage = "El fax no puede superar los 15 caracteres.")]
        public string Fax { get; set; }
    }
}
