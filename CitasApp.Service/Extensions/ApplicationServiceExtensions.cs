// una clase estaticaa es cuando no se necesita 3 ninguna extension

using CitasApp.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Service.Extensions;

public static class ApplicationServiceExtensions {
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config){
            services.AddDbContext<DataContext>(opt => {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
    } 
}