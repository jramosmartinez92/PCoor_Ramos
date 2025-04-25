using System.ComponentModel.DataAnnotations;

namespace PCoor_Ramos.Web.Models
{
    public class ClasificacionViewModel
    {
        public int ReclamoId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de clasificación.")]
        public string TipoClasificacion { get; set; } = string.Empty; // Datos estaticos segun requisito: "Reclamo", "Asesoria", "Aviso" (Jose Ramos)

        public string? MotivoAsesoria { get; set; }

        public string? DetalleAviso { get; set; }
    }
}
