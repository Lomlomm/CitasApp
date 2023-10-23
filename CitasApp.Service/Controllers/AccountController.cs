using System.Security.Cryptography;
using System.Text;
using CitasApp.Service.Entities;
using CitasApp.Service.Data;
using CitasApp.Service.DTOs;
using CitasApp.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasApp.Service.Interfaces;

namespace CitasApp.Service.Controllers;

public class AccountController : BaseApiController{
    private readonly DataContext _context;

    private const string USER_PASSWORD_ERROR_MESSAGE = "Usuario o contrasenia incorrectos";
    private readonly ITokenService _tokenService;
    public AccountController(DataContext context, ITokenService tokenService){
        _context = context; 
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto){
        if(await UserExists(registerDto.Username)) 
            return BadRequest("Ya existe nombre de usuario"); 

        // using en las lineas de codigo significa que en cuanto el objeto se libere, ejecute el garbage collector y lo quite de la memoria
        using var hmac = new HMACSHA512(); 

        var user = new AppUser{
            UserName = registerDto.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        }; 
        _context.User.Add(user); 
        await _context.SaveChangesAsync(); 

        return new UserDto{
            UserName = user.UserName, 
            Token = _tokenService.CreateToken(user)
        }; 
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto){


        var user = await _context.User.SingleOrDefaultAsync(x => 
            x.UserName.ToLower() == loginDto.Username.ToLower()
        );
        
        if (user == null) return Unauthorized(USER_PASSWORD_ERROR_MESSAGE); 

        // using en las lineas de codigo significa que en cuanto el objeto se libere, ejecute el garbage collector y lo quite de la memoria
        using var hmac = new HMACSHA512(user.PasswordSalt); 

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for(int i = 0; i < computedHash.Length; i++)
        {
            if(computedHash[i] != user.PasswordHash[i]) return Unauthorized(USER_PASSWORD_ERROR_MESSAGE);
        }

        return new UserDto{
            UserName = user.UserName, 
            Token = _tokenService.CreateToken(user)
        }; 
    }


    private async Task<bool> UserExists(string username){
        // un entity framework permite hacer consultas a una basededatos sin sql (linq)
        // en que se relacionan entity framework con linq? <-pregunta de entrevista
        // la funcion dentro de los parentesis son delegados: funciones anonimas, funciones no anonimas y funciones lambda
        // Un delegado permite enviar metodos como parametros
        return await _context.User.AnyAsync(x => x.UserName == username.ToLower()); //validamos que exista el usuario

    }
}