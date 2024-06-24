using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //DataAnnotation Configuran el enrutamiento y el comportamiento de los métodos en una API de ASP.NET Core.
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("/users")]
        public IActionResult GetUser()
        {
            return Ok(_userServices.GetUsers());
        }

        [HttpGet("/admin")]
        public IActionResult GetAdmin()
        {
            return Ok(_userServices.GetAdmins());
        }

        [HttpGet("/client")]
        public IActionResult GetClient()
        {
            return Ok(_userServices.GetClients());
        }

        [HttpGet("/AllReservationUser{idUser}")]
        public IActionResult GetAllReservationUser([FromRoute]int idUser)
        {
            return Ok(_userServices.GetAllReservationUser(idUser));
        }


        [HttpGet("/userbyid{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            return Ok(_userServices.GetById(id));
        }

        [HttpPost("/Admin")]
        public IActionResult CreateAdmin([FromBody] UserCreateRequest admin)
        {
            _userServices.CreateAdmin(admin);
            return Ok();
        }
        [HttpPost("/Client")]
        public IActionResult CerateClient([FromBody] UserCreateRequest client)
        {
            _userServices.CreateClient(client);
            return Ok();
        }


        [HttpPut("/Update{idUser}")]
        public IActionResult Update([FromBody] UserCreateRequest user, [FromRoute] int idUser)
        {
            _userServices.Update(user, idUser);
            return Ok();
        }


        [HttpDelete("/Delete{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _userServices.DeleteById(id);
            return Ok();
        }


    }
}