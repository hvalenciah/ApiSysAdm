/**
 *
 * @file Program.cs
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ADP.API.Model.Data.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.Services.Balcan;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<BalcanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BalcanDB")));

// Servicios
builder.Services.AddScoped<IModuloService, ModuloService>();
builder.Services.AddScoped<IModuloVistaService, ModuloVistaService>();
builder.Services.AddScoped<IPermisoService, PermisoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVistaService, VistaService>();
builder.Services.AddScoped<IVistaUsuarioService, VistaUsuarioService>();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", 
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration["OpenApiInfo:Title"],
        Version = builder.Configuration["OpenApiInfo:Version"],
        Description = builder.Configuration["OpenApiInfo:Description"]
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
