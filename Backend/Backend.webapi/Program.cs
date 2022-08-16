using System.Data;
using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.Configuration;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Interface;
using Backend.Services.Services;
using IConfiguration = Backend.DataAccessLibrary.Configuration.IConfiguration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//todo - in the future make separate folders for different di 
builder.Services.AddSingleton<IConfiguration>(configuration.GetSection("Configuration").Get<Configuration>());
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IOrderService, OrderService>();

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
