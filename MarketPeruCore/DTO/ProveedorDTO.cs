using System.ComponentModel.DataAnnotations;

namespace MarketPeruCore.DTO
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        [StringLength(40, ErrorMessage = "El nombre del proveedor no puede superar los 40 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre del representante es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre del representante no puede superar los 30 caracteres.")]
        public string Representante { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(60, ErrorMessage = "La dirección no puede superar los 60 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [StringLength(15, ErrorMessage = "La ciudad no puede superar los 15 caracteres.")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio.")]
        [StringLength(15, ErrorMessage = "El departamento no puede superar los 15 caracteres.")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio.")]
        [StringLength(15, ErrorMessage = "El código postal no puede superar los 15 caracteres.")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
        public string Telefono { get; set; }

        [StringLength(15, ErrorMessage = "El fax no puede superar los 15 caracteres.")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }
    }
}
