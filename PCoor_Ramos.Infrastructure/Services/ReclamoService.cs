using PCoor_Ramos.Application.Interfaces;
using PCoor_Ramos.Application.Services;
using PCoor_Ramos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCoor_Ramos.Infrastructure.Services
{
    public class ReclamoService : IReclamoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReclamoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reclamo>> ObtenerReclamosAsync()
        {
            return await _unitOfWork.Reclamos.GetWithEstadoAsync();
        }

        public async Task CrearReclamoAsync(Reclamo reclamo)
        {
            await _unitOfWork.Reclamos.AddAsync(reclamo);
            await _unitOfWork.SaveAsync();
        }
    }
}
