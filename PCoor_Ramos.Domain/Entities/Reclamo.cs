using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Domain.Entities
{

    [Table("t_Reclamo")]
    public class Reclamo
    {
        [Key]
        [Column("idReclamo")]
        public int Id { get; set; }

        [Column("nombreProveedor")]
        [Required, StringLength(50)]
        public string NombreProveedor { get; set; } = string.Empty;

        [Column("direccionProveedor")]
        [Required, StringLength(50)]
        public string DireccionProveedor { get; set; } = string.Empty;

        [Column("detalleReclamo")]
        [StringLength(250)]
        public string? DetalleReclamo { get; set; }

        [Column("telefonoProveedor")]
        [StringLength(10)]
        public string? TelefonoProveedor { get; set; }

        [Column("montoReclamado")]
        [DataType(DataType.Currency)]
        public decimal MontoReclamado { get; set; }

        [Column("fechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("fechaRevision")]
        public DateTime? FechaRevision { get; set; } // debe ser nullable segun el documento de requisitos (Jose Ramos)

        [Column("idEmpleado")]
        public int EmpleadoId { get; set; }

        [Column("idConsumidor")]
        public int ConsumidorId { get; set; }

        [Column("idEstado")]
        public int EstadoId { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        // Relaciones cardinales (Jose Ramos)
        public Empleado? Empleado { get; set; }
        public Consumidor? Consumidor { get; set; }
        public Estado? Estado { get; set; }

        public Asesoria? Asesoria { get; set; }
        public Aviso? Aviso { get; set; }
        public Propuesta? Propuesta { get; set; }
    }
}

