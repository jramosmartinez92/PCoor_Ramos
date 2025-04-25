using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Domain.Entities
{
    [Table("c_Empleado")]
    public class Empleado
    {
        [Key]
        [Column("idEmpleado")]
        public int Id { get; set; }

        [Column("nombres")]
        [Required, StringLength(50)]
        public string Nombres { get; set; } = string.Empty;

        [Column("apellidos")]
        [Required, StringLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        [Column("usuario")]
        [Required, StringLength(50)]
        public string Usuario { get; set; } = string.Empty;

        [Column("clave")]
        [Required, StringLength(50)]
        public string Clave { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<Reclamo>? Reclamos { get; set; }
    }

}
