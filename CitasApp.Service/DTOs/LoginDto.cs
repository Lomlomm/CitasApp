using System.ComponentModel.DataAnnotations;

namespace CitasApp.Service.DTOs; 

public class LoginDto {
    [Required]
    public string Username {get; set; }
    [Required]
    public string Password {get; set; }

}