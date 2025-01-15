using System.Text;
using AppService.Application;
using AppService.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISecurityService, SecurityService>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Valida o emissor do token
            ValidateAudience = true, // Valida o p�blico do token
            ValidateLifetime = true, // Valida o tempo de vida do token
            ValidateIssuerSigningKey = true, // Valida a chave de assinatura
            //ValidIssuer = builder.Configuration["Jwt:Issuer"], // Emissor configurado
            //ValidAudience = builder.Configuration["Jwt:Audience"], // P�blico configurado
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // Chave de assinatura
        };
    });
var app = builder.Build();

Console.WriteLine($"Ambiente: {app.Environment.EnvironmentName}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication(); // Habilita autentica��o
app.UseAuthorization(); // Habilita autoriza��o

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
