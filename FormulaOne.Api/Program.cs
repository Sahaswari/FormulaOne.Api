using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.DependencyInjection;
using FormulaOne.DataService.Data;
using Microsoft.EntityFrameworkCore;
//using FormulaOne.DataService.Data;


var builder = WebApplication.CreateBuilder(args);

//Get connection string
var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

//Initialising my DbContext inside the DI Container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(ConnectionStrings));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


