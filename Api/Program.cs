using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

const string cnn = "Server=.;Database=Teste;User Id=sa;Password=X*qchd&pth;";

builder.Services
    .AddControllers()
    .AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgenciaContext>(o =>
{
    o.UseSqlServer(cnn, options =>
    {
        options.MigrationsHistoryTable("__AgenciaMigrationHistory");
    });

});
builder.Services.AddDbContext<MateriaisContext>(o =>
{
    o.UseSqlServer(cnn, options =>
    {
        options.MigrationsHistoryTable("__MateriaisMigrationHistory");
    });

});
builder.Services.AddDbContext<FaturamentoContext>(
    o =>
    {
        o.UseSqlServer(cnn, options =>
        {
            options.MigrationsHistoryTable("__FaturamentoMigrationHistory");
        });

    });


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
