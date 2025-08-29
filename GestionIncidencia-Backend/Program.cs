using Incidencias.Aplicacion.Service;
using Incidencias.Dominio.IRepositorio;
using Incidencias.Infraestructura.Data.Dbcontext;
using Incidencias.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<IncidenciasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p => p
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IIncidenciaRepositorio, IncidenciaRepositorio>();
builder.Services.AddScoped<IAlumnoRepositorio, AlumnoRepositorio>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IncidenciaService>();
builder.Services.AddScoped<AlumnoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var env = app.Environment;
        var feature = context.Features.Get<IExceptionHandlerFeature>();
        var ex = feature?.Error;
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var problem = new
        {
            title = "Internal Server Error",
            message = ex?.Message,
            detail = env.IsDevelopment() ? ex?.StackTrace : null
        };
        await context.Response.WriteAsJsonAsync(problem);
    });
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();
app.MapGet("/api/ping", () => new { ok = true, serverUtc = DateTime.UtcNow });

app.MapControllers();

app.Run();
