using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationServices _reservationService;

        public ReservationController(IReservationServices reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //--Solo el admin puede usar el getall--
            //int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            return Ok(_reservationService.GetAll());
        }
        [HttpGet("GetById{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Solo puede acceder el admin
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            return Ok(_reservationService.GetById(id));
        }

        [HttpPost("CreateReservation")]
        public IActionResult Create()
        {
            //Solo puede crear reservaciones el cliente.
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Client")
                return Forbid();
            _reservationService.Create(userId);
            return Ok();
        }

        [HttpPut("IdFinalizedReservation{id}")]
        public IActionResult FinalizedReservation([FromRoute] int id)
        {
            _reservationService.FinalizedReservation(id);
            return Ok();
        }
        [HttpPut("AddSneakerToResrevation{idSneaker}")]
        public IActionResult AddToReservation([FromRoute] int idSneaker, [FromQuery] int idReservation)
        {
            //Solo ´puede agregar zapatillas el cliente.
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Client")
                return Forbid();
            _reservationService.AddToReservation(idSneaker, idReservation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _reservationService.Delete(id);
            return Ok();
        }



    }
}