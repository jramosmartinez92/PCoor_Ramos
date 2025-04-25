using System.ComponentModel.DataAnnotations;

namespace PCoor_Ramos.Web.Models
{
    public class PropuestaViewModel
    {
        [Required(ErrorMessage = "El detalle de la propuesta es obligatorio")]
        [Display(Name = "Detalle de la Propuesta")]
        public string DetallePropuesta { get; set; } = string.Empty;

        [Display(Name = "Respuesta del Consumidor")]
        public string? RespuestaConsumidor { get; set; }

        [Display(Name = "Aceptada")]
        public bool? Aceptada { get; set; }

        public int ReclamoId { get; set; }
    }
}
