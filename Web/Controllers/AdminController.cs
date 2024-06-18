using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminServices _adminServices;

        public AdminController(AdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpPost]
        public IActionResult createUser([FromBody] AdminDto user)
        {
            return Ok(_adminServices.create(user)); //se pone un dto
        }
    }
}