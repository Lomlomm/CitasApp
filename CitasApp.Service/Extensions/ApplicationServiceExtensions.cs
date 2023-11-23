// una clase estatica= es cuando no se necesita 3 ninguna instancia

using CitasApp.Service.Data;
using Microsoft.EntityFrameworkCore;
using CitasApp.Service.Interfaces; 
using CitasApp.Service.Services;
using API.Interfaces;

namespace CitasApp.Service.Extensions;

public static class ApplicationServiceExtensions {
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>(); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
    } 
}