using CitasApp.Service.DTOs;
using CitasApp.Service.Entities;
using CitasApp.Service.Interfaces;
 
namespace CitasApp.Service.Data;
 
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
 
    public UsersRepository(DataContext context)
    {
        _context = context;
 
    }

    public async Task<MemberDto> GetMemberAsync(string username){
        return await _context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(); 
    }
 
    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
        throw new NotImplementedException();
    }
 
    public Task<AppUser> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
 
    public Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        throw new NotImplementedException();
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