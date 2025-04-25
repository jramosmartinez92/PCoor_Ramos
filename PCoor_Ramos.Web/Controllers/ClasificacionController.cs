using Microsoft.AspNetCore.Mvc;
using PCoor_Ramos.Domain.Entities;
using PCoor_Ramos.Infrastructure.Data;
using PCoor_Ramos.Web.Models;

namespace PCoor_Ramos.Web.Controllers
{
    public class ClasificacionController : Controller
    {
        private readonly AppDbContext _context;

        public ClasificacionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Clasificar(int id)
        {
            var reclamo = await _context.Reclamos.FindAsync(id);

            if (reclamo == null || reclamo.EstadoId != 1)
                return NotFound();

            var vm = new ClasificacionViewModel { ReclamoId = id };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clasificar(ClasificacionViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var reclamo = await _context.Reclamos.FindAsync(vm.ReclamoId);
                if (reclamo == null)
                    return NotFound();

                reclamo.FechaRevision = DateTime.Now;

                switch (vm.TipoClasificacion.ToLower())
                {
                    case "asesoria":
                        reclamo.EstadoId = 2; // Supongamos que 2 es "Asesoría"
                        var asesoria = new Asesoria
                        {
                            FechaIngreso = DateTime.Now,
                            MotivoAsesoria = vm.MotivoAsesoria!,
                            ReclamoId = reclamo.Id,
                            Activo = true
                        };
                        _context.Asesorias.Add(asesoria);
                        break;

                    case "aviso":
                        reclamo.EstadoId = 3; // Supongamos que 3 es "Aviso de Infracción"
                        var aviso = new Aviso
                        {
                            FechaIngreso = DateTime.Now,
                            DetalleAviso = vm.DetalleAviso!,
                            ReclamoId = reclamo.Id,
                            Activo = true
                        };
                        _context.Avisos.Add(aviso);
                        break;

                    case "reclamo":
                        reclamo.EstadoId = 4; // Estado de "Reclamo formal"
                        break;

                    default:
                        ModelState.AddModelError("", "Tipo de clasificación inválido.");
                        return View(vm);
                }

                _context.Reclamos.Update(reclamo);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return RedirectToAction("Index", "Reclamo");
            }
            catch (Exception ex)
            {
                var error = ex;
                await transaction.RollbackAsync();
                ModelState.AddModelError("", "Error al clasificar el reclamo.");
                return View(vm);
            }
        }
    }
}
