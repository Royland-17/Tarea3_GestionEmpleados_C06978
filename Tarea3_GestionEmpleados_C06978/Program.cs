using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C06978.Data;
// NUEVO: Importamos la carpeta de repositorios
using Tarea3_GestionEmpleados_C06978.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// NUEVO: Registro del servicio para el Repositorio
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

// MODIFICADO: Cambiamos "Home" por "Empleados" para ir directo a la tarea
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
