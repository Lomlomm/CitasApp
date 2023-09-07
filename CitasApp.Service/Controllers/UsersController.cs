using API.entities;
using CitasApp.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
// [ApiController] Anotaciones
[ApiController]
[Route("api/[controller]")] // api/users
public class UsersController: ControllerBase {
    //patron de estrategia y dependencias, el primero son entidades que viven menos tiempo 
    // que la inyecci'on de dependencias
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
        return await _context.User.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id) {
        return await _context.User.FindAsync(id);
    }
}