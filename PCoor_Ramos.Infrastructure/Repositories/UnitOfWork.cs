using PCoor_Ramos.Application.Interfaces;
using PCoor_Ramos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IReclamoRepository Reclamos { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Reclamos = new ReclamoRepository(context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
