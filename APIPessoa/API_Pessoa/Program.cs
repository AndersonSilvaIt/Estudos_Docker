using APIPessoa.Business.Interfaces;
using APIPessoa.Data;
using APIPessoa.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseNpgsql(connection, builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
    .CommandTimeout(10));
});

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

// Aplica automaticamente as migrations ao iniciar a aplicação
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Contexto>();
    dbContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
