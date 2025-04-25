using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Domain.Entities
{
    [Table("c_Estado")]
    public class Estado
    {
        [Key]
        [Column("idEstado")]
        public int Id { get; set; }

        [Column("nombreEstado")]
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Reclamo>? Reclamos { get; set; }
    }
}
