using System.Data;
using Backend.DataAccessLibrary;
// using Backend.DataAccessLibrary.UnitOfWork;
using Backend.DataAccessLibraryEF.DbContext;
using Backend.Services.Interface;
using Backend.Services.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IConfiguration>(configuration.GetSection("Configuration").Get<Configuration>());


// var connectionString = builder.Configuration.GetConnectionString("Sample_Database");
var connectionString = "Server=localhost; Port=6603; Database=et_databaseEF; Uid=root; Pwd=pieczywo;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        .UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString));
});


// builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();
// builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderTypesService, OrderTypesService>();
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
