using Domain.Interfaces;
using Infrastructure.Configuracao;
using Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ContextDb>(opts =>
    opts.UseLazyLoadingProxies().UseMySQL(builder.Configuration.GetConnectionString("ConnectionString")));


// INTERFACE E REPOSITORIO
builder.Services.AddScoped(typeof(IGeneric<>), typeof(RepositorioGenerico<>));
builder.Services.AddSingleton<IHeroi, RepositorioHeroi>();
builder.Services.AddSingleton<ISuperpoder, RepositorioSuperpoderes>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

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

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
