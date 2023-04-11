using Microsoft.EntityFrameworkCore;
using ProEventos.Application;
using ProEventos.Application.Interfaces;
using ProEventos.Persistence;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Intefaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                             Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IGeralRepository, GeralRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProEventosContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();
