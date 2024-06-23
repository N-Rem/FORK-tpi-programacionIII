using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(_reservationService.GetAll());
        }
        [HttpGet("GetById{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_reservationService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromQuery] int idUser)
        {
            _reservationService.Create(idUser);
            return Ok();
        }

        [HttpPut("IdReservation{id}")]
        public IActionResult FinalizedReservation([FromRoute] int id)
        {
            _reservationService.FinalizedReservation(id);
            return Ok();
        }
        [HttpPut("IdSneaker{idSneaker}")]
        public IActionResult AddToReservation([FromRoute] int idSneaker, [FromQuery] int idReservation)
        {
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