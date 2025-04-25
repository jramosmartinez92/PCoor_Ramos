using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Domain.Entities
{
    [Table("t_Aviso")]
    public class Aviso
    {
        [Key]
        [Column("idAviso")]
        public int Id { get; set; }

        [Column("fechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("detalleAviso")]
        [Required, StringLength(500)]
        public string DetalleAviso { get; set; } = string.Empty;

        [Column("idReclamo")]
        public int ReclamoId { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        [ForeignKey("ReclamoId")]
        public Reclamo Reclamo { get; set; } = null!;
    }
}
