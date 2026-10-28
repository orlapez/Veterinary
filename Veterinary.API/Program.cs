using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using Veterinary.API.Data;
using Veterinary.API.Helpers;
using Veterinary.Shared.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Veterinary API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                      Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                      Example: 'Bearer 12345abcdef'<br /> <br />",


        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});



builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection"));
builder.Services.AddTransient<SeedDb>(); builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserHelper, UserHelper>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Agregar autenticación JWT
    .AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuer = false, // Validar el emisor del token
        ValidateAudience = false,// Validar el destinatario del token
        ValidateLifetime = true,// Validar la expiración del token
        ValidateIssuerSigningKey = true,// Validar la clave de firma del token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"]!)),// Clave secreta para firmar el token
        ClockSkew = TimeSpan.Zero // Desviación del reloj
    });




var app = builder.Build();

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





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Veterinary API v1");
    });
}


app.UseHttpsRedirection();

app.UseAuthentication();    

app.UseAuthorization();

app.MapControllers();



app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());


app.Run();
