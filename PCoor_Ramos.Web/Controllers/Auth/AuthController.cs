using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PCoor_Ramos.Infrastructure.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PCoor_Ramos.Web.Controllers.Auth
{
   
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string clave)
        {
            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.Usuario == usuario && e.Clave == clave && e.Activo);

            if (empleado == null)
            {
                ViewBag.Error = "Usuario o clave inválidos.";
                return View();
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, empleado.Id.ToString()),
            new Claim(ClaimTypes.Name, empleado.Usuario),
            new Claim(ClaimTypes.GivenName, empleado.Nombres + " " + empleado.Apellidos)
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}