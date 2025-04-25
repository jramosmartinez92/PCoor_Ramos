using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReclamoRepository Reclamos { get; }

        Task<int> SaveAsync();
    }
}
