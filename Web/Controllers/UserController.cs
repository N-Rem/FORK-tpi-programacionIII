using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            return Ok(_userServices.GetUsers());
        }
        [HttpGet("Clients")]
        public IActionResult GetClients()
        {
            return Ok(_userServices.GetClients());
        }
        [HttpGet("Admins")]
        public IActionResult GetAdmins()
        {
            return Ok(_userServices.GetAdmins());
        }

        [HttpGet("User{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_userServices.GetById(id));
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserCreateRequest user)
        {
            return Ok(_userServices.CreateUser(user));
        }

        [HttpPut("UpdateUser{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserUpdateRequest user)
        {
            _userServices.Update(id, user);
            return Ok();
        }

        [HttpDelete("Delete{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _userServices.DeleteById(id);
            return Ok();
        }

        
    }
}