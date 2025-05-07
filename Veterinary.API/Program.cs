using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


//Inyecciones de dependencias

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Veterinary API",
        Version = "v1"
    });
});
builder.Services.AddDbContext<DataContext>(x=>x.UseSqlServer("name=DefaultConnection"));
builder.Services.AddTransient<SeedDb>();


var app = builder.Build();

//Midleware
app.UseCors(x => x

.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope scope = scopedFactory!.CreateScope())
    {
        SeedDb service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}



//Midlewares




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Veterinary API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
