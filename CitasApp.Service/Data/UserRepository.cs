using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CitasApp.Service.DTOs;
using CitasApp.Service.Entities;
using CitasApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CitasApp.Service.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 

    }

    public async Task<MemberDto> GetMemberAsync(string username)
    {
        return await _context.User
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public Task<MemberDto> GetMemberAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        return await _context.User
        .Include(p => p.Photos)
        .SingleOrDefaultAsync( u => u.UserName == username); 

    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.User
        .Include(p => p.Photos)
        .ToListAsync();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(AppUser user)
    {
        throw new NotImplementedException();
    }
}