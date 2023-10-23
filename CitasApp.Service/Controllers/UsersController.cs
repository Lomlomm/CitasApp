using CitasApp.Service.Entities;
using CitasApp.Service.Controllers;
using CitasApp.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace CitasApp.Service.Controllers;

// [ApiController] Anotaciones
[Authorize]
public class UsersController: BaseApiController {
    //patron de estrategia y dependencias, el primero son entidades que viven menos tiempo 
    // que la inyecci'on de dependencias
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
        return await _context.User.ToListAsync();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id) {
        return await _context.User.FindAsync(id);
    }
}