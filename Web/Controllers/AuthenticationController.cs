using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private readonly IConfiguration _config;

        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration config)
        {
            _authenticationService = authenticationService;
            _config = config;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            string token = _authenticationService.Authenticate(authenticationRequest);
            return Ok(token);
        }
    }
}
