using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore; // 1. IMPORTANTE: Para poder usar SQL Server
using Vuelos.API.Data;             // 2. IMPORTANTE: Para encontrar tu VuelosContext
                                   // (Si esta línea se pone roja, verifica el namespace en VuelosContext.cs)

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS (Lo que usa tu App) ---

// A. Configurar la Base de Datos
// Esto lee la cadena "DefaultConnection" que configuraste en el paso anterior
builder.Services.AddDbContext<VuelosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// B. Configurar CORS (Permisos)
// Esto permite que cualquier Frontend (Blazor, React, etc.) se conecte a tu API sin bloqueos
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()   // Permite cualquier origen
              .AllowAnyMethod()   // Permite GET, POST, PUT, DELETE
              .AllowAnyHeader();  // Permite cualquier cabecera
    });
});

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Configuración de Swagger (Documentación de la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- 2. CONFIGURACIÓN DEL PIPELINE (Cómo responde tu App) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// C. Activar CORS (¡OJO: Debe ir antes de Authorization!)
app.UseCors("PermitirTodo");

app.UseAuthorization();

app.MapControllers();

app.Run();