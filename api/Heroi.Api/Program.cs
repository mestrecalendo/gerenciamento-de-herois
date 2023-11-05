using Domain.Interfaces;
using Infrastructure.Configuracao;
using Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ContextDb>(opts =>
    opts.UseMySQL(builder.Configuration.GetConnectionString("ConnectionString")));


// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositorioGenerico<>));
builder.Services.AddSingleton<IHeroi, RepositorioHeroi>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
