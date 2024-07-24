using MarketPeruCore.Interfaces;
using MarketPeruCore.Models;
using MarketPeruCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MarketPeruContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

//CONFIGURANDO SERVICES ADD
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IGuiaService, GuiaService>();
builder.Services.AddScoped<ILocalService, LocalService>();
builder.Services.AddScoped<IOrdenService, OrdenService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
