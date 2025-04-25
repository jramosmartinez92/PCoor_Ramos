
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCoor_Ramos.Infrastructure.Data;
using PCoor_Ramos.Web.Models;
using PCoor_Ramos.Domain.Entities;

namespace PCoor_Ramos.Web.Controllers
{
    [Authorize]
    public class PropuestaController : Controller
    {
        private readonly AppDbContext _context;

        public PropuestaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Crear(int reclamoId)
        {
            var vm = new PropuestaViewModel { ReclamoId = reclamoId };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PropuestaViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var propuesta = new Propuesta
            {
                ReclamoId = vm.ReclamoId,
                DetallePropuesta = vm.DetallePropuesta,
                RespuestaConsumidor = vm.RespuestaConsumidor,
                Aceptada = vm.Aceptada
            };

            _context.Propuestas.Add(propuesta);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Reclamo");
        }
    }
}

