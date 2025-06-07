using Valyan.API.Data;
using System.Data;
using Dapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DbConnectionFactory>();

var app = builder.Build();

// Health check la startup pentru conexiunea la baza de date

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
