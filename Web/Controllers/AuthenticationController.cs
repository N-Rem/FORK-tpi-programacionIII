using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // Un servicio para manejar la lógica de autenticación.
        private IAuthenticationService _authenticationService;

        //es una interfaz proporcionada por ASP.NET Core
        //Se utiliza para acceder a configuraciones en el archivo appsettings.json u otras fuentes de configuración.
        //Nos ayuda a meternos en el appsettin.json "Clave:valor"
        private readonly IConfiguration _config;

        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration config)
        {
            _authenticationService = authenticationService;
            _config = config;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            //Llama a un metodo que devuelve un string-Token
            string token = _authenticationService.Authenticate(authenticationRequest);
            return Ok(token);
        }
    }
}
