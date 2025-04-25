using Microsoft.EntityFrameworkCore;
using PCoor_Ramos.Application.Interfaces;
using PCoor_Ramos.Domain.Entities;
using PCoor_Ramos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Infrastructure.Repositories
{
    public class ReclamoRepository : GenericRepository<Reclamo>, IReclamoRepository
    {
        public ReclamoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Reclamo>> GetWithEstadoAsync()
        {
            return await _context.Reclamos
                .Include(r => r.Estado)
                .Include(r => r.Empleado)
                .Include(r => r.Consumidor)
                .ToListAsync();
        }
    }
}
