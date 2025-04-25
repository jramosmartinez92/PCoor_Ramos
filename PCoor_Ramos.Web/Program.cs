using Microsoft.EntityFrameworkCore;
using PCoor_Ramos.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using PCoor_Ramos.Application.Interfaces;
using PCoor_Ramos.Infrastructure.Repositories;
using PCoor_Ramos.Application.Services;
using PCoor_Ramos.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
// Mantener una transacion en el ORM-EF y confirma si todo es correcto (Jose Ramos)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Registro de los servicios
builder.Services.AddScoped<IReclamoService, ReclamoService>();

// Inyeccion de SQL (Jose Ramos)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

// LOGIN - Autenticacion global , se usa cookies (Jose Ramos)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.Cookie.Name = "PCoorAuth";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// AUTENTICACIÓN Y AUTORIZACIÓN (Jose Ramos)
app.UseAuthentication();
app.UseAuthorization();

// Ejecutar SeedData , datos iniciales (Jose Ramos)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await SeedData.InitializeAsync(context);
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
