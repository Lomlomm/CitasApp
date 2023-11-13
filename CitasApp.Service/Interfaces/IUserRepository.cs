using CitasApp.Service.DTOs;
using CitasApp.Service.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    Task<MemberDto> GetMemberAsync();
    Task<IEnumerable<MemberDto>> GetMembersAsync();

    Task<AppUser> GetUserByIdAsync(int id);
    Task<AppUser> GetUserByUsernameAsync(string username);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<bool> SaveAllAsync();
    void Update(AppUser user);

}