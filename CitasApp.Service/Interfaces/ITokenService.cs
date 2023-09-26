using CitasApp.Service.Entities;

namespace CitasApp.Service.Interfaces;

// una interfaz es para establecer un contrato o blueprint de los métodos que debe contener la clase que lo implementa
// la diferencia con una clase abstracta es que la abstracta usa herencia, mientras que las interfaces se implementan 
// una clase abstracta puede tener implmentaciones de métodos, definiciones de métodos y propiedades
// una interfaz sólo tiene de métodos aunque actualmente se pueden agregar propiedades
// ninguna de las dos se puede instanciar 
// las clases abstractas pueden hacer más complejo el sistema debido a sus mecanismos de herencia 
// usualmente nada más se estila usar las firmas de los métodos
public interface ITokenService
{
    string CreateToken(AppUser user);

}
