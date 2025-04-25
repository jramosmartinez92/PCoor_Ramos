using PCoor_Ramos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Application.Services
{
    public interface IReclamoService
    {
        Task<IEnumerable<Reclamo>> ObtenerReclamosAsync();
        Task CrearReclamoAsync(Reclamo reclamo);
    }
}
