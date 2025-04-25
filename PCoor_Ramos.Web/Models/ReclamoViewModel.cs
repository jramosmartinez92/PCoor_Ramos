using Microsoft.AspNetCore.Mvc.Rendering;
using PCoor_Ramos.Domain.Entities;

namespace PCoor_Ramos.Web.Models
{
    public class ReclamoViewModel
    {
        public Reclamo Reclamo { get; set; } = new Reclamo();
        public IEnumerable<SelectListItem>? Estados { get; set; }
        public IEnumerable<SelectListItem>? Empleados { get; set; }
        public IEnumerable<SelectListItem>? Consumidores { get; set; }
    }
}
