
namespace CitasApp.Service.Entities{
    public class AppUser{

        public int Id { get; set; }


        public string UserName { get; set;}
        
        public byte[] PasswordHash { get; set; }

// Generamos otra llave para encriptar, asi hacemos mas seguro el almacenamiento del password
// EL password salt cambia para cada password aunque las contrasenias sean iguales
        public byte[] PasswordSalt { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow; 

        public DateTime LastActive { get; set; } = DateTime.UtcNow; 

        public string Gender { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<Photo> Photos { get; set; } = new(); 

        public int DameLaEdad( ) 
        {
            return DateOfBirth.CalculateAge(); 
        }

        
    }

}