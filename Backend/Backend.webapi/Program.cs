using System.Text;
using Backend.DAL_EF;
using Backend.Services.Interface;
using Backend.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Backend.Services;
using CloudSql;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IJwtConfiguration>(configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>());

var connectionString = builder.Configuration.GetSection("Configuration").GetSection("MySqlDatabase").Value;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderTypesService, OrderTypesService>();
var tokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = configuration["JwtConfiguration:Issuer"],
    ValidAudience = configuration["JwtConfiguration:Issuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfiguration:Key"]))
};
builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = tokenValidationParameters;
    });

// const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//
// builder.Services.AddCors(o=>
//     o.AddPolicy(name: MyAllowSpecificOrigins,
//         policy =>
//         {
//             policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
//         }));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
    .WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();
