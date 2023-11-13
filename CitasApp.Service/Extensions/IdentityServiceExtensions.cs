// una clase estatica= es cuando no se necesita 3 ninguna instancia

using CitasApp.Service.Data;
using Microsoft.EntityFrameworkCore;
using CitasApp.Service.Interfaces; 
using CitasApp.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CitasApp.Service.Extensions;

public static class IdentityServiceExtensions {
    public static IServiceCollection AddIdentityServices(
        this IServiceCollection services,
        IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true, 
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(config["TokenKey"])),
                            ValidateIssuer = false, 
                            ValidateAudience = false
                        };
                }
            
            ); 
            return services;
        }
    
}