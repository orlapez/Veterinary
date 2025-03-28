using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


//Inyecciones de dependencias

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x=>x.UseSqlServer("name=DefaultConnection"));



var app = builder.Build();




//Midlewares




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
