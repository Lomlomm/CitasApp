namespace CitasApp.Service.Data;

using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using CitasApp.Service.Entities;
using Microsoft.EntityFrameworkCore; 

public class Seed 
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.User.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json"); 
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; 
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        foreach ( var user in users )
        {
            using var hmac = new HMACSHA512(); 
            user.UserName = user.UserName.ToLower(); 
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd")); 
            user.PasswordSalt = hmac.Key; 

            context.User.Add(user); 
        }

        await context.SaveChangesAsync(); 
        
    }
}