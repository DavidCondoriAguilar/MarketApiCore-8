using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPeruCore.DTO
{
    public class OrdenDTO
    {
        public int IdOrden { get; set; }

        [Required(ErrorMessage = "La Fecha de la Orden es obligatoria.")]
        public DateTime FechaOrden { get; set; }

        [Required(ErrorMessage = "La Fecha de Entrada es obligatoria.")]
        public DateTime FechaEntrada { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }
    }
}
