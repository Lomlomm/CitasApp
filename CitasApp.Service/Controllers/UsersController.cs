using CitasApp.Service.Entities;
using CitasApp.Service.Controllers;
using CitasApp.Service.Data;
using CitasApp.Service.DTOs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API.Interfaces;
namespace CitasApp.Service.Controllers;

// [ApiController] Anotaciones
[Authorize]
public class UsersController: BaseApiController {
    //patron de estrategia y dependencias, el primero son entidades que viven menos tiempo 
    // que la inyecci'on de dependencias
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository; 
        _mapper = mapper; 
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() {
        var users = await _userRepository.GetUsersAsync();
        var data = _mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(data);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username) {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        
        return _mapper.Map<MemberDto>(user);
    }
}