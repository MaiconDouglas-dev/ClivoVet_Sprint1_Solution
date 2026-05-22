using Microsoft.EntityFrameworkCore;
using ClivoVetApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Oracle + EF Core (Item 3 da Sprint)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger/OpenAPI (Item 4 da Sprint)
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "ClivoVet API", Version = "v1", Description = "API de Gestão Preventiva Pet" });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClivoVet API V1");
    c.RoutePrefix = string.Empty; // Isso faz o Swagger abrir direto no http://localhost:5000/
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
