using DesafioFastBack.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura o Banco para PostgreSQL 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configura o CORS (Fundamental para o Angular conseguir acessar a API)
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// 3. Liberar Documentação em Produção 
app.MapOpenApi();
app.MapScalarApiReference();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/openapi/v1.json", "Minha API v1");
    options.RoutePrefix = "swagger"; // Acessível em: url-do-render/swagger
});

// 4. Rodar Migrations Automaticamente (Cria as tabelas no banco do Render ao subir)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (db.Database.GetPendingMigrations().Any())
    {
        db.Database.Migrate();
    }
}

app.UseCors("AllowAll"); // Ativa a política de acesso
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();