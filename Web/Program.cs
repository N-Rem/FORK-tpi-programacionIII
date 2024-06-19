using Application.Interfaces;
using Application.Services;
using Domain.Interface;
using Infrastructure.Data;//Para que aceda al contexto. 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

//Add - Migration InitialMigration - Context ApplicationContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AdminServices>();




//Se crea la base de datos
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(
builder.Configuration["ConnectionStrings:EcommerceDBConnectionString"], b => b.MigrationsAssembly("Infrastructure")));

//Inyeciones
builder.Services.AddScoped<IRepositorySneaker,RepositorySneaker>();
builder.Services.AddScoped<IRepositoryReservation,RepositoryReservation>();

builder.Services.AddScoped<IReservationService, ReservationService>();


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