using Incidencias.Aplicacion.Service;
using Incidencias.Dominio.IRepositorio;
using Incidencias.Infraestructura.Data.Dbcontext;
using Incidencias.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IncidenciasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Add services to the container.
builder.Services.AddControllers();

// Repositorios
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IIncidenciaRepositorio, IncidenciaRepositorio>();
builder.Services.AddScoped<IAlumnoRepositorio, AlumnoRepositorio>(); // registro alumno

// Servicios de aplicación
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IncidenciaService>();
builder.Services.AddScoped<AlumnoService>(); // servicio alumno

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
