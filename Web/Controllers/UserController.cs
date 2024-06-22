using Application.Interfaces;
using Application.Models;
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
        private readonly IUserServices _adminServices;
        private readonly IReservationServices _reservationService;
        private readonly ISneakerServices _sneakerServices;

        public UserController(IUserServices adminServices, IReservationServices reservationService, ISneakerServices sneakerService)
        {
            _adminServices = adminServices;
            _reservationService = reservationService;
            _sneakerServices = sneakerService;
        }


        //Crud Admin
        [HttpPost("CreateAdmin")]
        public IActionResult createAdmin([FromBody] AdminDto user)
        {
            return Ok(_adminServices.CreateAdmin(user));
        }


        [HttpGet("getAdmin")]
        public IActionResult GetAdmins()
        {
            return Ok(_adminServices.GetAdmins());
        }

        [HttpGet("Admin{id}")]
        public IActionResult GetAdminById([FromRoute] int id)
        {
            return Ok(_adminServices.GetById(id));
        }

        [HttpPut("putAdmin")]
        public IActionResult UpdateAdmin([FromBody] AdminDto admin)
        {
            _adminServices.Update(admin);
            return Ok();
        }

        [HttpDelete("admin{id}")]
        public IActionResult DeleteAdmin([FromRoute] int id)
        {
            _adminServices.DeleteById(id);
            return Ok();
        }

        // Crud Sneaker
        [HttpPost("CreateSneaker")]
        public IActionResult CreateSneaker([FromBody] SneakerDto sneaker)
        {
            return Ok(_sneakerServices.Create(sneaker));
        }


        [HttpGet("getSneaker")]
        public IActionResult GetSneaker()
        {
            return Ok(_sneakerServices.GetSneaker());
        }

        [HttpGet("Sneaker{id}")]
        public IActionResult GetSneakerById([FromRoute] int id)
        {
            return Ok(_sneakerServices.GetById(id));
        }

        [HttpPut("putSneaker")]
        public IActionResult UpdateAdmin([FromBody] SneakerDto sneaker)
        {
            _sneakerServices.Update(sneaker);
            return Ok();
        }

        [HttpDelete("sneaker{id}")]
        public IActionResult DeleteSneaker([FromRoute] int id)
        {
            _sneakerServices.DeleteById(id);
            return Ok();
        }

        [HttpGet("Brand{brand}")]

        public IActionResult GetByBrand([FromRoute] string brand)
        {
            return Ok(_sneakerServices.GetByBrand(brand));
        }

        [HttpGet("Category{category}")]
        public IActionResult GetByCategory(string category)
        {
            return Ok(_sneakerServices.GetByCategory(category));
        }

        //Crud Reservation

        [HttpGet("Reservation")]
        public IActionResult GetReservations()
        {
            return Ok(_reservationService.GetAll());
        }

        [HttpGet("ReservationId{id}")]
        public IActionResult GetReservationById([FromRoute] int id)
        {
            return Ok(_reservationService.GetById(id));
        }

        [HttpDelete("deleteReservation{id}")]
        public IActionResult DeleteReservation([FromRoute] int id)
        {
            _reservationService.Delete(id);
            return Ok();
        }


    }
}