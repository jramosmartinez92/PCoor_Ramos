using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Domain.Entities
{
    [Table("t_Propuesta")]
    public class Propuesta
    {
        [Key]
        [Column("idPropuesta")]
        public int Id { get; set; }

        [Column("idReclamo")]
        public int ReclamoId { get; set; }

        [Column("detallePropuesta")]
        [Required, StringLength(500)]
        public string DetallePropuesta { get; set; } = string.Empty;

        [Column("respuestaConsumidor")]
        [StringLength(500)]
        public string? RespuestaConsumidor { get; set; }

        [Column("aceptada")]
        public bool? Aceptada { get; set; }

        [ForeignKey("ReclamoId")]
        public Reclamo Reclamo { get; set; } = null!;
    }

}
