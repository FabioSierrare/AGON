using E_Commerce.Context;
using E_Commerce; // Namespace donde está DependencyInjectionService
using Microsoft.EntityFrameworkCore;
using MicroServiceCRUD;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios externos definidos en DependencyInjectionService
builder.Services.AddExternal(builder.Configuration);

// Configurar la cadena de conexión para el DbContext
builder.Services.AddDbContext<E_commerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
