using System.ComponentModel.DataAnnotations;

namespace PCoor_Ramos.Web.Models
{
    public class RegisterEmpleadoModel
    {
        [Required, StringLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Usuario { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [DataType(DataType.Password)]
        public string Clave { get; set; } = string.Empty;

        [Required, Compare("Clave", ErrorMessage = "Las claves no coinciden.")]
        [DataType(DataType.Password)]
        public string ConfirmarClave { get; set; } = string.Empty;
    }
}
