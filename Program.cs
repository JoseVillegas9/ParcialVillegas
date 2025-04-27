using FutbolPeruano.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Puerto de escucha
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://localhost:{port}"); // 👈 CAMBIO IMPORTANTE: usar localhost

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Configurar la cadena de conexión
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection") 
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

// 🚀 Mostrar la cadena de conexión para debug
Console.WriteLine($"Connection string (debug): {connectionString}");

// Agregar ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
);

var app = builder.Build();

// Configurar el pipeline de HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurar las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();