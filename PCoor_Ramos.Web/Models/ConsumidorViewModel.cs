// PCoor_Ramos.Web/Models/ConsumidorViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace PCoor_Ramos.Web.Models;

public class ConsumidorViewModel
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50)]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "El DUI es obligatorio")]
    [StringLength(10)]
    [RegularExpression("^[0-9]{8}-[0-9]{1}$", ErrorMessage = "Formato de DUI inválido (ej. 12345678-9)")]
    public string Dui { get; set; } = string.Empty;
}

