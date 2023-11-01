using CitasApp.Service.Entities;
using CitasApp.Service.Controllers;
using CitasApp.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
namespace CitasApp.Service.Controllers;

// [ApiController] Anotaciones
[Authorize]
public class UsersController: BaseApiController {
    //patron de estrategia y dependencias, el primero son entidades que viven menos tiempo 
    // que la inyecci'on de dependencias
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public UsersController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {
        var users = await _userRepository.GetUsersAsync();
        var usersToReturn = _mapper.Map<IEnumerable(MemberDto)>(users);
        return await _context.User.ToListAsync();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id) {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        
        return _mapper.Map<MemberDto>(user);
    }
}