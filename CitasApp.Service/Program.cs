using System.Text;
using CitasApp.Service;
using CitasApp.Service.Data;
using CitasApp.Service.Extensions;
using CitasApp.Service.Interfaces;
using CitasApp.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
// builder.Services.AddSingleton permite agregar un servicio singleton del tipo especificado en el servicetime 
// builder.Services.Transcient 
// por cada inyeccion de ITokenService implementará una clase llamada token service
builder.Services.AddScoped<ITokenService, TokenService>(); //esto es una inyección de dependencias
// la inyección de dependencias sirve para desacoplar la aplicación, mejor su mantenibilidad y hacer más 
// fáciles las pruebas. Se relaciona con el principio de SOLID de Dependency Inversion Principle 

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Aquí hay cambios pendientes de inyección de Token Service
// Si se tiene una clase sellada sin codigo fuente que no se puede heredar, como podemos poner un metodo? 
// La herencia se evita para no complicar la estructura del c'odigo, para esto existen metodos de extencion: OJITOJITO

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options => 

//         {
//             options.TokenValidationParameters = new TokenValidationParameters
//             {
//                 ValidateIssuerSigningKey = true, 
//                 IssuerSigningKey = new SymmetricSecurityKey(
//                     Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
//                 ValidateIssuer = false, 
//                 ValidateAudience = false
//             };
//         });

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader()
                                .AllowAnyMethod()
                                .WithOrigins("http://localhost:4200")); 

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

