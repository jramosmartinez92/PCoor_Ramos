using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCoor_Ramos.Application.Services;
using PCoor_Ramos.Domain.Entities;
using PCoor_Ramos.Infrastructure.Data;
using PCoor_Ramos.Web.Models;

namespace PCoor_Ramos.Web.Controllers
{
    [Authorize]
    public class ReclamoController : Controller
    {
        private readonly IReclamoService _reclamoService;
        private readonly AppDbContext _context;

        public ReclamoController(IReclamoService reclamoService, AppDbContext context)
        {
            _reclamoService = reclamoService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reclamos = await _reclamoService.ObtenerReclamosAsync();
            return View(reclamos);
        }
        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var reclamo = await _context.Reclamos
                .Include(r => r.Estado)
                .Include(r => r.Empleado)
                .Include(r => r.Consumidor)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reclamo == null)
                return NotFound();

            return View(reclamo);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var vm = new ReclamoViewModel
            {
                Estados = await _context.Estados
                            .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre })
                            .ToListAsync(),
                Empleados = await _context.Empleados
                            .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombres + " " + e.Apellidos })
                            .ToListAsync(),
                Consumidores = await _context.Consumidores
                            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre + " " + c.Apellido })
                            .ToListAsync()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ReclamoViewModel vm)
        {
            vm.Reclamo.FechaIngreso = DateTime.Now;
            vm.Reclamo.Activo = true;

            if (!ModelState.IsValid)
            {
                
                // Volver a llenar dropdowns si hay error (Jose Ramos)
                vm.Estados = await _context.Estados
                    .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre })
                    .ToListAsync();

                vm.Empleados = await _context.Empleados
                    .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombres + " " + e.Apellidos })
                    .ToListAsync();

                vm.Consumidores = await _context.Consumidores
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre + " " + c.Apellido })
                    .ToListAsync();

                return View(vm);
            }

            await _reclamoService.CrearReclamoAsync(vm.Reclamo);
            return RedirectToAction("Index");
        }
    }
}
