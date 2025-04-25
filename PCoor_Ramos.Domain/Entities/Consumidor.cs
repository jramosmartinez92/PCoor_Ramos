using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Domain.Entities
{
    [Table("c_Consumidor")]
    public class Consumidor
    {
        [Key]
        [Column("idConsumidor")]
        public int Id { get; set; }

        [Column("nombreConsumidor")]
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Column("apellidoConsumidor")]
        [Required, StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Column("direccion")]
        [Required, StringLength(50)]
        public string Direccion { get; set; } = string.Empty;

        [Column("correoElectronico")]
        [Required, StringLength(50)]
        public string Correo { get; set; } = string.Empty;

        [Column("duiConsumidor")]
        [Required, StringLength(10)]
        public string Dui { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        public ICollection<Reclamo>? Reclamos { get; set; }
    }
}
