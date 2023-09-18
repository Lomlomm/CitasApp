using System.Security.Cryptography;
using System.Text;
using API.entities;
using CitasApp.Service.Data;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Service.Controllers;

public class AccountController : BaseApiController{
    private readonly DataContext _context;
    public AccountController(DataContext context){
        _context = context; 

    }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(string username, string password){
        // using en las lineas de codigo significa que en cuanto el objeto se libere, ejecute el garbage collector y lo quite de la memoria
        using var hmac = new HMACSHA512(); 

        var user = new AppUser{
            UserName = username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        }; 
        _context.User.Add(user); 
        await _context.SaveChangesAsync(); 

        return user; 
    }
}