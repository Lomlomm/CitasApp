using API.entities;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Service.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options) {

        }
        public DbSet<AppUser> User { get; set; }
    }
}