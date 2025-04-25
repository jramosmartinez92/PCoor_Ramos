// PCoor_Ramos.Web/Controllers/ConsumidorController.cs
using Microsoft.AspNetCore.Mvc;
using PCoor_Ramos.Infrastructure.Data;
using PCoor_Ramos.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using PCoor_Ramos.Web.Models;

namespace PCoor_Ramos.Web.Controllers;

[Authorize]
public class ConsumidorController : Controller
{
    private readonly AppDbContext _context;

    public ConsumidorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(ConsumidorViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (_context.Consumidores.Any(c => c.Dui == model.Dui))
        {
            ModelState.AddModelError("Dui", "Este DUI ya está registrado.");
            return View(model);
        }

        var consumidor = new Consumidor
        {
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            Dui = model.Dui,
            Activo = true
        };

        _context.Consumidores.Add(consumidor);
        await _context.SaveChangesAsync();

        // Redirigir al formulario de reclamo (opcional: podrías usar TempData para confirmar)
        return RedirectToAction("Crear", "Reclamo");
    }
}

