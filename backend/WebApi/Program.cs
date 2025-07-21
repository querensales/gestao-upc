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
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsLivre", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IRecordService, RecordService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

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
// Aplicando migra��es
using (var scope = app.Services.CreateScope())
{
    await Task.Delay(TimeSpan.FromSeconds(30));
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migra��es.");
        // Tratar a exce��o adequadamente. Em produ��o, voc� provavelmente deveria abortar a inicializa��o.
    }
}

Console.WriteLine($"Ambiente: {app.Environment.EnvironmentName}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsLivre");
app.UseAuthentication(); // Habilita autentica��o
app.UseAuthorization(); // Habilita autoriza��o

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
