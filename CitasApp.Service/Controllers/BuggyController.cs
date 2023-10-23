using CitasApp.Service.Controllers;
using CitasApp.Service.Data;
using CitasApp.Service.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Service; 

public class BuggyController : BaseApiController
{
    private readonly DataContext _context; 

    public BuggyController(DataContext context){
        _context = context;
    }

    [Authorize]
    [HttpPost("auth")]
    public ActionResult<string> GetSecret()
    {
        return "Secreto de la API";
    }
    [HttpPost("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        
        var thing = _context.User.Find(-1);

        if (thing == null) return NotFound();

        return thing; 
    }

    [HttpPost("server-error")]
    public ActionResult<string> GetServerError()
    {
        var thing = _context.User.Find(-1); 

        var thingToReturn = thing.ToString(); 

        return thingToReturn;
    }

    [HttpPost("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("Usted ha solicitado algo de forma incorrecta");
    }
}