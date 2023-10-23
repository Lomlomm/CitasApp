using System.ComponentModel.DataAnnotations;

namespace CitasApp.Service.Entities{
    public class AppUser{

        public string UserName { get; set;}
        public int Id { get; set; }

        
        public byte[] PasswordHash { get; set; }

// Generamos otra llave para encriptar, asi hacemos mas seguro el almacenamiento del password
// EL password salt cambia para cada password aunque las contrasenias sean iguales
        public byte[] PasswordSalt { get; set; }
    }
}