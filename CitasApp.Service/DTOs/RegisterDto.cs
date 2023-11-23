using System.ComponentModel.DataAnnotations;

namespace CitasApp.Service.DTOs{
    public class RegisterDto{
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4)]
        // Se pueden aplicar expresiones regulares de la siguiente manera 
        public string Password { get; set; }

    }
}