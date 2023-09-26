using System.Security.Principal;

namespace CitasApp.Service.DTOs; 

public class UserDto
{
    public string UserName {get; set; }
    public string Token { get; set;}
}