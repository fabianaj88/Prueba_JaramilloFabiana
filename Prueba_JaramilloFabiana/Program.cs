using Microsoft.EntityFrameworkCore;
using Prueba_JaramilloFabiana.Models;
using Prueba_JaramilloFabiana.Repositorys;
using Prueba_JaramilloFabiana.Services;
using System.Text.Json.Serialization;
//using Prueba_JaramilloFabiana.Service;

var builder = WebApplication.CreateBuilder(args);
// Agrega el servicio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Especifica el origen
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FormularioRepository>();
builder.Services.AddScoped<CampoRepository>();
builder.Services.AddScoped<RespuestaRepository>();
builder.Services.AddScoped<RegistroRepository>();

builder.Services.AddScoped<FormularioService>();
builder.Services.AddScoped<CampoService>();
builder.Services.AddScoped<RespuestaService>();
builder.Services.AddScoped<RegistroService>();

builder.Services.AddDbContext<FullStackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();


