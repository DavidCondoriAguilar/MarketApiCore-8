using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPeruCore.DTO
{
    public class GuiaDTO
    {
        public int IdGuia { get; set; }

        [Required(ErrorMessage = "El IdLocal es obligatorio.")]
        public int IdLocal { get; set; }

        [Required(ErrorMessage = "La Fecha de Salida es obligatoria.")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "El nombre del transportista es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del transportista no puede superar los 100 caracteres.")]
        public string Transportista { get; set; }
    }
}
