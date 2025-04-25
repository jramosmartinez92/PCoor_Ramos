// PCoor_Ramos.Web/Controllers/Auth/RegisterController.cs
using Microsoft.AspNetCore.Mvc;
using PCoor_Ramos.Infrastructure.Data;
using PCoor_Ramos.Domain.Entities;
using PCoor_Ramos.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace PCoor_Ramos.Web.Controllers.Auth;

public class RegisterController : Controller
{
    private readonly AppDbContext _context;

    public RegisterController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Crear(RegisterEmpleadoModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (_context.Empleados.Any(e => e.Usuario == model.Usuario))
        {
            ModelState.AddModelError("Usuario", "El nombre de usuario ya está en uso.");
            return View(model);
        }

        var nuevo = new Empleado
        {
            Nombres = model.Nombres,
            Apellidos = model.Apellidos,
            Usuario = model.Usuario,
            Clave = model.Clave,
            Activo = true
        };

        _context.Empleados.Add(nuevo);
        await _context.SaveChangesAsync();

        return RedirectToAction("Login", "Auth");
    }
}
